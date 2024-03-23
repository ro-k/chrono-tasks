import {Component, OnInit} from '@angular/core';
import {TreeViewStore} from "../../../../state/stores/tree-view-store";
import {CategoryStore} from "../../../../state/stores/category-store";
import {AsyncPipe, NgForOf} from "@angular/common";
import {map, Observable, switchMap} from "rxjs";
import {Category} from "../../../../core/models/category";
import {TreeView} from "../../../../core/models/tree-view";
import {ContentViewItem} from "../../../../core/models/content-view-item";

@Component({
  selector: 'app-content-pane',
  templateUrl: './content-pane.component.html',
  styleUrl: './content-pane.component.css'
})
export class ContentPaneComponent implements OnInit {

  categories$: Observable<Category[]>;
  treeView$: Observable<TreeView>;
  content$: Observable<ContentViewItem[]>;

  constructor(private treeViewStore: TreeViewStore, private categoryStore: CategoryStore) {
    this.categories$ = this.categoryStore.categories$;
    this.treeView$ = this.treeViewStore.treeView$;
    this.content$ = this.treeViewStore.contentViewItems$;
  }

  ngOnInit(){
    this.categoryStore.load();
  }

  expand(item: ContentViewItem) {
    this.treeViewStore.navigateIntoItem(item);
    //this.treeViewStore.setViewingPath({...defaultViewingPath, category: item.id});
    // let item = {...this.viewingPath$.getValue()}

  }

  protected readonly alert = alert;
}
