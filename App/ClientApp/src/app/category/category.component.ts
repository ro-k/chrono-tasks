import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Category} from "../shared/models/category";
import {CategoryService} from "../shared/services/category.service";

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

  constructor(private categoryService: CategoryService) { }

  updateCategory(category: Category) {
    console.log('updating in category component');
    this.categoryService.updateCategory(this.category).subscribe(
      {
        next: () => {
          // Handle successful update
          console.log(`Category with ID ${this.category.categoryId} updated successfully`);
          this.update.emit(this.category);
        }, error: error => {
          // Handle error
          console.error('Error occurred while updating category:', error);
        }
      });
  }

  deleteCategory() {
    this.categoryService.deleteCategory(this.category).subscribe(
      {
        next: () => {
          // Handle successful deletion
          console.log(`Category with ID ${this.category.categoryId} deleted successfully`);
          this.delete.emit(this.category);
        }, error: error => {
          // Handle error
          console.error('Error occurred while deleting category:', error);
        }
      });
  }
}


