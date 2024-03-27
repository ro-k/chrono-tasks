import {Component, OnInit} from '@angular/core';
import {TreeViewStore} from "../../../../state/stores/tree-view-store";
import {CategoryStore} from "../../../../state/stores/category-store";
import {Observable} from "rxjs";
import {Category} from "../../../../core/models/category";
import {TreeView} from "../../../../core/models/tree-view";
import {ContentViewItem} from "../../../../core/models/content-view-item";
import {ItemType} from "../../../../core/models/item-type";

@Component({
  selector: 'app-content-pane',
  templateUrl: './content-pane.component.html',
  styleUrl: './content-pane.component.css'
})
export class ContentPaneComponent implements OnInit {

  parentItem: ContentViewItem = {id: '', name:'..', description:'', type:ItemType.Unknown, createdAt:null, modifiedAt:null};

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

  expand(item: ContentViewItem, up = false) {
    if(up) {
      this.treeViewStore.navigateUp();
      return;
    }

    this.treeViewStore.navigateIntoItem(item);
  }

  protected readonly alert = alert;
}
