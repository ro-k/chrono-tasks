import {Component, OnInit} from '@angular/core';
import {TreeViewCategory} from "../../../../core/models/tree-view-category";
import {TreeView} from "../../../../core/models/tree-view";
import {TreeViewService} from "../../services/tree-view.service";
import {TreeViewUI} from "../../../../core/models/tree-view-ui";
import {Observable} from "rxjs";
import {TreeViewStore} from "../../../../state/stores/tree-view-store";
import {CategoryStore} from "../../../../state/stores/category-store";
import {JobStore} from "../../../../state/stores/job-store";
import {ActivityStore} from "../../../../state/stores/activity-store";

@Component({
  selector: 'app-tree-view-explorer',
  templateUrl: './tree-view-explorer.component.html',
  styleUrls: ['./tree-view-explorer.component.css']
})
export class TreeViewExplorerComponent implements OnInit {
  treeCategories: TreeViewCategory[] = [];
  treeView: TreeView = { categories: this.treeCategories };

  treeView$: Observable<TreeView>;

  constructor(private treeViewStore: TreeViewStore,
              private categoryStore: CategoryStore,
              private jobStore: JobStore,
              private activityStore: ActivityStore) {
    this.treeView$ = treeViewStore.treeView$;
  }

  ngOnInit(): void {
      this.fetchTreeView();
  }

  fetchTreeView(): void {
    this.categoryStore.load();

    // this.treeViewService.getTreeView().subscribe(
    //   {
    //     next: (tv) => {
    //       this.treeView = tv;
    //       this.treeCategories = tv.categories;
    //     },
    //     error: console.error
    //   }
    // );
  }

  toggle(treeItem: any|TreeViewUI) {
    //treeItem.isExpanded = !treeItem.isExpanded;
    this.treeViewStore.toggleExpand(treeItem);
  }
}
