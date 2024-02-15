import {Component, Input, OnInit} from '@angular/core';
import { TreeViewCategory } from '../shared/models/treeViewCategory';
import {Expandable} from "../shared/models/expandable";
import {AppState} from "../shared/models/appState";
import {TreeViewService} from "../shared/services/tree-view.service";

@Component({
  selector: 'app-tree-view',
  templateUrl: './tree-view.component.html',
  styleUrls: ['./tree-view.component.css']
})
export class TreeViewComponent implements OnInit {
  treeCategories: TreeViewCategory[] = [];
  treeView: AppState = { categories: this.treeCategories };

  constructor(private treeViewService: TreeViewService) { }

  ngOnInit(): void {
      this.fetchTreeView();
  }

  fetchTreeView(): void {
    this.treeViewService.getTreeView().subscribe(
      {
        next: (tv) => {
          this.treeView = tv;
          this.treeCategories = tv.categories;
        },
        error: console.error
      }
    );
  }

  toggle(treeItem: Expandable) {
    treeItem.isExpanded = !treeItem.isExpanded;
  }
}
