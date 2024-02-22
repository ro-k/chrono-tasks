import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Category} from "../../../../core/models/category";
import {CategoryService} from "../../services/category.service";
import {CategoryStore} from "../../../../state/stores/category-store";

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent {
  @Input() category!: Category;
  @Output() delete = new EventEmitter<Category>();
  @Output() update = new EventEmitter<Category>();
  @Output() add = new EventEmitter<Category>();
  isExpanded = false;
  showConfirmDelete = false;
  showEdit = false;

  constructor(private categoryStore: CategoryStore) { }

  updateCategory(category: Category) {
    console.log('updating in category component');
    this.categoryStore.update(category);
    // this.categoryService.update(category).subscribe(
    //   {
    //     next: () => {
    //       // Handle successful update
    //       console.log(`Category with ID ${this.category.categoryId} updated successfully`);
    //       this.update.emit(this.category);
    //     }, error: error => {
    //       // Handle error
    //       console.error('Error occurred while updating category:', error);
    //     }
    //   });
  }

  deleteCategory() {
    this.categoryStore.delete(this.category);
    // this.categoryService.delete(this.category).subscribe(
    //   {
    //     next: () => {
    //       // Handle successful deletion
    //       console.log(`Category with ID ${this.category.categoryId} deleted successfully`);
    //       this.delete.emit(this.category);
    //     }, error: error => {
    //       // Handle error
    //       console.error('Error occurred while deleting category:', error);
    //     }
    //   });
  }
}


