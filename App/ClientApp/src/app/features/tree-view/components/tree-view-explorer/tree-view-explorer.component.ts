import {Component, OnInit} from '@angular/core';
import {TreeView} from "../../../../core/models/tree-view";
import {TreeViewUI} from "../../../../core/models/tree-view-ui";
import {Observable} from "rxjs";
import {TreeViewStore} from "../../../../state/stores/tree-view-store";
import {CategoryStore} from "../../../../state/stores/category-store";
import {JobStore} from "../../../../state/stores/job-store";
import {ActivityStore} from "../../../../state/stores/activity-store";

@Component({

  selector: 'app-tree-view-explorer',
  templateUrl: './tree-view-explorer.component.html',
  styleUrls: ['./tree-view-explorer.component.scss']
})
export class TreeViewExplorerComponent implements OnInit {
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
  }

  toggle(treeItem: any|TreeViewUI) {
    this.treeViewStore.toggleExpand(treeItem);
  }
}
