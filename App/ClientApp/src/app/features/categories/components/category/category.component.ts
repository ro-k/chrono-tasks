import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Category} from "../../../../core/models/category";
import {CategoryStore} from "../../../../state/stores/category-store";

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent {
  @Input() category!: Category;
  isExpanded = false;
  showConfirmDelete = false;
  showEdit = false;
  constructor(private categoryStore: CategoryStore) { }

  updateCategory(category: Category) {
    console.log('updating in category component');
    this.categoryStore.update(category);
  }

  deleteCategory() {
    this.categoryStore.delete(this.category);
  }
}


