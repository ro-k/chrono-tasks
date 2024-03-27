import {Component, OnInit} from '@angular/core';
import {TreeViewStore} from "../../../../state/stores/tree-view-store";
import {CategoryStore} from "../../../../state/stores/category-store";
import {BehaviorSubject, combineLatest, map, Observable} from "rxjs";
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
  filteredContent$: Observable<ContentViewItem[]>;

  private filterTerms = new BehaviorSubject<string>('');

  constructor(private treeViewStore: TreeViewStore, private categoryStore: CategoryStore) {
    this.categories$ = this.categoryStore.categories$;
    this.treeView$ = this.treeViewStore.treeView$;
    this.content$ = this.treeViewStore.contentViewItems$;
    this.filteredContent$ = combineLatest([this.content$, this.filterTerms])
      .pipe(
        map(([items, filterTerm]) => {
          return items.filter(item =>
            filterTerm === '' ||
            item.name.toLowerCase().includes(filterTerm.toLowerCase()) ||
            (item.description && item.description.toLowerCase().includes(filterTerm.toLowerCase()))
          );
        }),
      );
  }

  ngOnInit(){
    this.categoryStore.load();
  }

  expand(item: ContentViewItem, up = false) {
    if(up) {
      this.treeViewStore.navigateUp();
      return;
    }
    this.handleFilter(''); // clear filter
    this.treeViewStore.navigateIntoItem(item);
  }

  // handle the filter, update BehaviorSubject
  handleFilter(term: string) {
    this.filterTerms.next(term);
  }

  protected readonly alert = alert;
}
