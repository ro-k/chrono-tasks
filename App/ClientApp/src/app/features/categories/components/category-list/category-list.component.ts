import {Component, OnInit} from '@angular/core';
import {Category} from "../../../../core/models/category";
import {CategoryStore} from "../../../../state/stores/category-store";
import {BehaviorSubject, combineLatest, map, Observable} from "rxjs";
import {NothingHereComponent} from "../../../../shared/components/nothing-here/nothing-here.component";
import {ItemType} from "../../../../core/models/item-type";


@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {
  showAdd = false;
  categories$: Observable<Category[]>;
  filteredCategories$: Observable<Category[]>;
  headerType:Set<ItemType> = new Set<ItemType>([ItemType.Category]);
  protected readonly alert = alert;

  private filterTerms = new BehaviorSubject<string>('');

  constructor(private categoryStore: CategoryStore) {
    this.categories$ = this.categoryStore.categories$;
    this.filteredCategories$ = combineLatest([this.categories$, this.filterTerms])
      .pipe(
        map(([items, filterTerm]) => {
          return items.filter(category =>
            filterTerm === '' ||
            category.name.toLowerCase().includes(filterTerm.toLowerCase()) ||
            (category.description && category.description.toLowerCase().includes(filterTerm.toLowerCase()))
          );
        }),
      );
  }

  ngOnInit(): void {
    this.categoryStore.load();
  }

  // handle the filter, update BehaviorSubject
  handleFilter(term: string) {
    this.filterTerms.next(term);
  }

  protected readonly NothingHereComponent = NothingHereComponent;
  protected readonly ItemType = ItemType;
}
