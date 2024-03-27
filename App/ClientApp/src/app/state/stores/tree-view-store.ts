import {Injectable} from "@angular/core";
import {TreeView} from "../../core/models/tree-view";
import {createStore, withProps} from "@ngneat/elf";
import {CategoryStore} from "./category-store";
import {JobStore} from "./job-store";
import {ActivityStore} from "./activity-store";
import {BehaviorSubject, combineLatestWith, EMPTY, map, Observable, of, switchMap} from "rxjs";
import {Category} from "../../core/models/category";
import {Activity} from "../../core/models/activity";
import {Job} from "../../core/models/job";
import {TreeViewCategory} from "../../core/models/tree-view-category";
import {TreeViewJob} from "../../core/models/tree-view-job";
import {TreeViewUI} from "../../core/models/tree-view-ui";
import {ItemType} from "../../core/models/item-type";
import {ContentViewItem} from "../../core/models/content-view-item";
import {getEntity, selectAllEntities, selectManyByPredicate} from "@ngneat/elf-entities";


@Injectable({
  providedIn: 'root',
})
export class TreeViewStore {
  // todo: rethink TreeView* items
  private store = createStore(
    { name: 'tree-view' },
    withProps<TreeView>({ categories: [] }),
  );

  private navigation: ContentViewItem[] = [];
  navigationSource = new BehaviorSubject<ContentViewItem[]>([]);

  treeView$ = this.store.pipe(map (s => s));
  navigationStack$ = this.navigationSource.asObservable();
  contentViewItems$: Observable<ContentViewItem[]> = EMPTY;

  constructor(private categoryStore: CategoryStore, private jobStore: JobStore, private activityStore: ActivityStore) {
    this.updateItems = this.updateItems.bind(this);
    this.setupTreeView();
    this.setupContentView();
  }

  private setupTreeView() {
    // update categories themselves
    this.categoryStore.categories$.pipe(
      map(categories =>
        this.updateItems<TreeViewCategory, Category>(this.store.state.categories, categories, (x) => x.categoryId, (tv, c) => ({...tv,...c as any,...{type:ItemType.Category}}))))
      .subscribe(categories => {
        this.store.update(treeView => ({...treeView, categories: categories}))});

    // update categories with jobs
    this.jobStore.jobs$.pipe(
      map(jobs =>
        this.updateCategoryJobs(this.store.state.categories, jobs)))
      .subscribe(categories => {
        this.store.update(treeView => ({...treeView, categories: categories}))});

    // update categories with activities
    this.activityStore.categoryActivities$.pipe(
      map(activities =>
        this.updateCategoryActivities(this.store.state.categories, activities)))
      .subscribe(categories => {
        this.store.update(treeView => ({...treeView, categories: categories}))});

    // update jobs with activities
    this.activityStore.jobActivities$.pipe(
      map(activities =>
      {
          const jobs = (this.store.state.categories.map(c => c.jobs ?? [])).flat();
          this.updateJobActivities(jobs, activities);
          return this.store.state.categories;
        }))
      .subscribe(categories => {
        this.store.update(treeView => ({...treeView, categories: categories}))});
  }

  private updateJobActivities(jobs: TreeViewJob[], activities: Activity[]) {
    const map = new Map<string, Activity[]>();

    activities.forEach(activity => {
      let jobId = activity.jobId;
      if(jobId !== null){
        let activitySet = map.get(jobId);
        if(activitySet === undefined) {
          map.set(jobId, [activity]);
        } else {
          activitySet.push(activity);
        }
      }
    });

    jobs.forEach(job => {
      let activitySet = map.get(job.jobId);
      if(activitySet === undefined) {
        job.activities = [];
      } else {
        job.activities = job.activities ?? [];
        job.activities = this.updateItems<Activity, Activity>(job.activities, activitySet, (a => a.activityId), (a1, a2) => ({...a1, ...a2}));
      }
    });

    return jobs;
  }

  private updateCategoryActivities(categories: TreeViewCategory[], activities: Activity[]) {
    const map = new Map<string, Activity[]>();

    activities.forEach(activity => {
      let categoryId = activity.categoryId;
      if(categoryId !== null){
        let activitySet = map.get(categoryId);
        if(activitySet === undefined) {
          map.set(categoryId, [activity]);
        } else {
          activitySet.push(activity);
        }
      }
    });

    categories.forEach(category => {
      let activitySet = map.get(category.categoryId);
      if(activitySet === undefined) {
        category.activities = [];
      } else {
        category.activities = category.activities ?? [];
        category.activities = this.updateItems<Activity, Activity>(category.activities, activitySet, (a => a.activityId), (a1, a2) => ({...a1, ...a2}));
      }
    });

    return categories;
  }

  private updateCategoryJobs(categories: TreeViewCategory[], jobs: Job[]) : TreeViewCategory[] {
    const map = new Map<string, Job[]>();

    jobs.forEach(job => {
      let jobSet = map.get(job.categoryId);
      if(jobSet === undefined) {
        map.set(job.categoryId, [{...job,...{type:ItemType.Job}}]);
      } else {
        jobSet.push({...job,...{type:ItemType.Job}});
      }
    });

    categories.forEach(category => {
      let jobSet = map.get(category.categoryId);
      if(jobSet === undefined) {
        category.jobs = [];
      } else {
        category.jobs = category.jobs ?? [];
        category.jobs = this.updateItems<TreeViewJob, Job>(category.jobs, jobSet, (j => j.jobId), (tj, j) => ({...tj, ...j as any}));
      }
    });

    return categories;
  }

  // generic update/merge method that maintains children
  private updateItems<T, U>(items1: T[], items2: U[], getId: (item: T | U) => string, mergeStrategy: (item1: T | U, item2: U) => T): T[] {
    const map = new Map<string, T>();
    const items2Ids = new Set(items2.map(item => getId(item)));

    // Add items from the first array to the map
    items1.forEach(item => {
      const id = getId(item);
      if (items2Ids.has(id)) {
        map.set(id, item);
      }
    });

    // Iterate over the second array, update or add items
    items2.forEach(item => {
      const id = getId(item);
      let currentItem = map.get(id);
      if (currentItem !== undefined) {
        // Merge using the provided mergeStrategy
        map.set(id, mergeStrategy(currentItem, item));
      } else {
        // Add new item to the map, assuming mergeStrategy can handle creating a T type from U
        map.set(id, mergeStrategy({} as T, item));
      }
    });

    return Array.from(map.values());
  }

  private setupContentView() {
    this.contentViewItems$ = this.navigationStack$.pipe(switchMap(stack => {
      debugger;
      if(stack.length === 0){
        return this.categoryStore.store.pipe(selectAllEntities(), map(categories => categories.map(c => this.categoryToContentViewItem(c))));
      }
      const top = stack[stack.length-1];

      // todo: activity
      if(top.type === ItemType.Activity) {
        // query activity from Activity store
        //const activity = this.activityStore.store.query(getEntity(top.id));

        // find matching treejob, call expand on it
        // const treeJob = this.store.state.categories.find(x => x.categoryId === job?.categoryId!)?.jobs!.find(x => x.jobId === top.id);
        // this.toggleExpand(treeJob, true);

        // select activities from store
        //return this.activityStore.store.pipe(selectManyByPredicate(x => x.jobId === top.id), map(activities => activities.map(a => this.activityToContentViewItem(a))));
        return of([]);
      }
      if(top.type === ItemType.Job) {
        // query job from jobStore
        const job = this.jobStore.store.query(getEntity(top.id));

        // find matching treejob, call expand on it
        const treeJob = this.store.state.categories.find(x => x.categoryId === job?.categoryId!)?.jobs!.find(x => x.jobId === top.id);
        this.toggleExpand(treeJob, true);

        // select activities from store
        return this.activityStore.store.pipe(selectManyByPredicate(x => x.jobId === top.id), map(activities => activities.map(a => this.activityToContentViewItem(a))));
      }
      if(top.type == ItemType.Category) {
        // find category, toggle expand
        const treeCategory = this.store.state.categories.find(x => x.categoryId === top.id);
        this.toggleExpand(treeCategory, true);

        // query stores for matching activities / jobs
        const activities$ = this.activityStore.store.pipe(selectManyByPredicate(x => x.categoryId === top.id), map(activities => activities.map(a => this.activityToContentViewItem(a))));
        const jobs$ = this.jobStore.store.pipe(selectManyByPredicate(x => x.categoryId === top.id), map(jobs => jobs.map(j => this.jobToContentViewItem(j))));
        return activities$.pipe(combineLatestWith(jobs$), map(([activities, jobs]) => [...activities, ...jobs]));
      }

      return EMPTY;
    }));
  }

  toggleExpand(item: any|TreeViewUI, expanded: boolean|undefined = undefined) {
    item.isExpanded = expanded ?? !item.isExpanded;

    if(item.isExpanded) {
      let type = item.type;
      if(type === ItemType.Category){
        this.tryGetCategory((item as TreeViewCategory).categoryId);
      }
      else if(type === ItemType.Job) {
        this.tryGetJob((item as TreeViewJob).jobId);
      } else {
        console.log('unknown tree view item');
        return;
      }
    }
  }

  tryGetCategory(id: string) {
    console.log('loading for categoryId: ' + id);
    this.activityStore.loadByCategoryId(id);
    this.jobStore.loadByCategoryId(id);
  }

  tryGetJob(id: string) {
    console.log('loading for jobId: ' + id);
    this.activityStore.loadByJobId(id);
  }

  navigateUp() {
    this.navigation.pop();
    this.navigationSource.next(this.navigation);
  }

  navigateIntoItem(item: ContentViewItem) {


    const newStack: ContentViewItem[] = [];
    let next : [type: ItemType, id: string] = [item.type, item.id];

    if(item.type === ItemType.Activity) {
      const activity = this.activityStore.store.query(getEntity(item.id));
      if(activity === undefined){
        throw new Error('id not found: ' + item);
      }
      newStack.unshift(this.activityToContentViewItem(activity));
      next = activity.jobId !== undefined ? [ItemType.Job, activity.jobId!] : [ItemType.Category, activity.categoryId!];
    }
    if(next[0] === ItemType.Job) {
      const job = this.jobStore.store.query(getEntity(next[1]));
      if(job === undefined) {
        throw new Error('id not found: ' + next);
      }
      newStack.unshift(this.jobToContentViewItem(job));
      next = [ItemType.Category, job.categoryId];
    }
    if(next[0] === ItemType.Category) {
      const category = this.categoryStore.store.query(getEntity(next[1]));
      if(category === undefined) {
        throw new Error('id not found: ' + next);
      }
      newStack.unshift(this.categoryToContentViewItem(category));
    }

    console.log('new nav stack:');
    console.log(newStack);
    this.navigation = newStack;
    this.navigationSource.next(newStack);
  }

  categoryToContentViewItem(value: Category) : ContentViewItem {
    return {createdAt: value.createdAt, description: value.description ?? "", id: value.categoryId, modifiedAt: value.modifiedAt, name: value.name, type: ItemType.Category};
  }

  jobToContentViewItem(value: Job) : ContentViewItem {
    return {createdAt: value.createdAt, description: value.description ?? "", id: value.jobId, modifiedAt: value.modifiedAt, name: value.name, type: ItemType.Job};
  }

  activityToContentViewItem(value: Activity) : ContentViewItem {
    return {createdAt: value.createdAt, description: value.description ?? "", id: value.activityId, modifiedAt: value.modifiedAt, name: value.name, type: ItemType.Activity};
  }
}
