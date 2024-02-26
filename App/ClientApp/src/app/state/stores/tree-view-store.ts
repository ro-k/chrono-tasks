import {Injectable} from "@angular/core";
import {TreeView} from "../../core/models/tree-view";
import {createStore, withProps} from "@ngneat/elf";
import {CategoryStore} from "./category-store";
import {JobStore} from "./job-store";
import {ActivityStore} from "./activity-store";
import {combineLatest, map} from "rxjs";
import {selectAllEntities} from "@ngneat/elf-entities";
import {Category} from "../../core/models/category";
import {Activity} from "../../core/models/activity";
import {Job} from "../../core/models/job";
import {TreeViewCategory} from "../../core/models/tree-view-category";
import {TreeViewActivity} from "../../core/models/tree-view-activity";


@Injectable({
  providedIn: 'root',
})
export class TreeViewStore {
  private store = createStore(
    { name: 'tree-view' },
    withProps<TreeView>({ categories: [], uiProps: new Map() })
  );

  treeView$ = this.store.pipe(map (s => s));

  constructor(private categoryStore: CategoryStore, private jobStore: JobStore, private activityStore: ActivityStore) {
    this.init();
  }

  private init() {
    // Set up combined subscription to entity stores
    combineLatest([
      this.categoryStore.categories$,
      this.jobStore.jobs$,
      this.activityStore.activities$,
    ]).pipe(
      map(([categories, jobs, activities]) => this.constructTreeNodes(categories, jobs, activities))
    ).subscribe(categories => {
      this.store.update(tv => ({...tv, categories: categories}));
    });
  }

  private constructTreeNodes(categories: Category[], jobs: Job[], activities: Activity[]): TreeViewCategory[] {
    // we expect treeView$ to already contain a base item

    return [];
  }

  private updateCategories(categories: Category[]) : TreeViewCategory[] {
    let treeViewCategories = this.store.state.categories;
    categories.forEach(c => {
      let match = treeViewCategories.find(x => x.entity.categoryId === c.categoryId);
      if(match === undefined) {
        treeViewCategories = [new class implements TreeViewCategory {
          activities = [];
          entity = c;
          isExpanded = false;
          jobs = [];
        }, ...treeViewCategories]
      }
      else {
        match.entity = c;
      }
    });
    return treeViewCategories;
}

  // Provide direct access to the store for actions and selectors
  get state() {
    return this.store;
  }
}
