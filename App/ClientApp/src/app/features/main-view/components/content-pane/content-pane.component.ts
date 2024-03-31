import {Component, OnInit} from '@angular/core';
import {TreeViewStore} from "../../../../state/stores/tree-view-store";
import {CategoryStore} from "../../../../state/stores/category-store";
import {BehaviorSubject, combineLatest, map, Observable} from "rxjs";
import {ContentViewItem} from "../../../../core/models/content-view-item";
import {ItemType} from "../../../../core/models/item-type";

@Component({
  selector: 'app-content-pane',
  templateUrl: './content-pane.component.html',
  styleUrl: './content-pane.component.css'
})
export class ContentPaneComponent implements OnInit {

  parentItem: ContentViewItem = {id: '', name:'..', description:'', type:ItemType.Unknown, createdAt:null, modifiedAt:null};
  currentType = new Set<ItemType>();
  addType : ItemType | null = null;

  content$: Observable<ContentViewItem[]>;
  filteredContent$: Observable<ContentViewItem[]>;

  private filterTerms = new BehaviorSubject<string>('');

  constructor(private treeViewStore: TreeViewStore, private categoryStore: CategoryStore) {
    this.content$ = this.treeViewStore.contentViewItems$;
    this.filteredContent$ = combineLatest([this.content$, this.filterTerms])
      .pipe(
        map(([items, filterTerm]) => {
          this.currentType.clear();
          return items.filter(item => {
              this.currentType.add(item.type);
              return filterTerm === '' ||
              item.name.toLowerCase().includes(filterTerm.toLowerCase()) ||
              (item.description && item.description.toLowerCase().includes(filterTerm.toLowerCase()))
            }
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

  handleAddEvent(itemType: ItemType) {
    this.addType = itemType;
  }

  protected readonly alert = alert;
  protected readonly ItemType = ItemType;
}
