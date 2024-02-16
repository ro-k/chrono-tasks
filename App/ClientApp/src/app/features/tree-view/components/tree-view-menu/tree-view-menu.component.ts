import {Component, Input, OnInit} from '@angular/core';
import {TreeViewCategory} from "../../../../core/models/treeViewCategory";
import {AppState} from "../../../../core/models/appState";
import {TreeViewService} from "../../services/tree-view.service";
import {Expandable} from "../../../../core/models/expandable";

@Component({
  selector: 'app-tree-view-menu',
  templateUrl: './tree-view-menu.component.html',
  styleUrls: ['./tree-view-menu.component.css']
})
export class TreeViewMenuComponent implements OnInit {
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
