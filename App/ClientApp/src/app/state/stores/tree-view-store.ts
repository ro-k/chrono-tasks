import {Injectable} from "@angular/core";
import {TreeView} from "../../core/models/tree-view";
import {createStore, withProps} from "@ngneat/elf";
import {CategoryStore} from "./category-store";
import {JobStore} from "./job-store";
import {ActivityStore} from "./activity-store";
import {map} from "rxjs";
import {Category} from "../../core/models/category";
import {Activity} from "../../core/models/activity";
import {Job} from "../../core/models/job";
import {TreeViewCategory} from "../../core/models/tree-view-category";
import {TreeViewJob} from "../../core/models/tree-view-job";
import {TreeViewItemType, TreeViewUI} from "../../core/models/tree-view-ui";


@Injectable({
  providedIn: 'root',
})
export class TreeViewStore {
  private store = createStore(
    { name: 'tree-view' },
    withProps<TreeView>({ categories: [] })
  );

  treeView$ = this.store.pipe(map (s => s));

  constructor(private categoryStore: CategoryStore, private jobStore: JobStore, private activityStore: ActivityStore) {
    this.updateItems = this.updateItems.bind(this);
    this.init();
  }

  private init() {

    // update categories themselves
    this.categoryStore.categories$.pipe(
      map(categories =>
        this.updateItems<TreeViewCategory, Category>(this.store.state.categories, categories, (x) => x.categoryId, (tv, c) => ({...tv,...c as any,...{type:TreeViewItemType.Category}}))))
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
        map.set(job.categoryId, [{...job,...{type:TreeViewItemType.Job}}]);
      } else {
        jobSet.push({...job,...{type:TreeViewItemType.Job}});
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

  toggleExpand(item: any|TreeViewUI) {
    item.isExpanded = !item.isExpanded;

    if(item.isExpanded) {
      let type = item.type;
      if(type === TreeViewItemType.Category){
        this.tryGetCategory(item);
      }
      else if(type === TreeViewItemType.Job) {
        this.tryGetJob(item);
      } else {
        console.log('unknown tree view item');
        return;
      }
    }
  }

  tryGetCategory(item: TreeViewCategory) {
    console.log('loading for categoryId: ' + item.categoryId);
    this.activityStore.loadByCategoryId(item.categoryId);
    this.jobStore.loadByCategoryId(item.categoryId);
  }

  tryGetJob(item: TreeViewJob) {
    console.log('loading for jobId: ' + item.jobId);
    this.activityStore.loadByJobId(item.jobId);
  }
}
