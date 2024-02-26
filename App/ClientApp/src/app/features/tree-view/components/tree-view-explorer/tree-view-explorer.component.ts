import {Component, OnInit} from '@angular/core';
import {TreeViewCategory} from "../../../../core/models/tree-view-category";
import {TreeView} from "../../../../core/models/tree-view";
import {TreeViewService} from "../../services/tree-view.service";
import {Expandable} from "../../../../core/models/expandable";

@Component({
  selector: 'app-tree-view-explorer',
  templateUrl: './tree-view-explorer.component.html',
  styleUrls: ['./tree-view-explorer.component.css']
})
export class TreeViewExplorerComponent implements OnInit {
  treeCategories: TreeViewCategory[] = [];
  treeView: TreeView = { categories: this.treeCategories };

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
