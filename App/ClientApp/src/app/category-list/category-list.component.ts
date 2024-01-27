import {Component, OnInit} from '@angular/core';
import {Category} from "../shared/models/category";
import {CategoryService} from "../shared/services/category.service";

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  categories: Category[] = [];
  showAdd = false;

  constructor(private categoryService: CategoryService) {  }
  ngOnInit(): void {
    this.fetchCategories();
  }

  fetchCategories(): void {
    this.categoryService.getCategories().subscribe(
      { next: (v) => this.categories = v, error: console.error }
    );
  }

  protected readonly alert = alert;

  deleteCategory(category: Category) {
    this.categories = this.categories.filter(x => x.categoryId !== category.categoryId);
  }

  updateCategory(category: Category) {
    const index = this.categories.findIndex(x => x.categoryId === category.categoryId);
    if (index !== -1) {
      this.categories[index] = category;
    }
  }

  createCategory(category: Category) {
    console.log('creating in category-list component');
    this.categoryService.createCategory(category).subscribe(
      {
        next: (createdCategory: Category) => {
          // Handle successful add
          console.log(`Category with ID ${createdCategory.categoryId} created successfully`);
          this.categories.unshift(createdCategory);
        }, error: error => {
          // Handle error
          console.error('Error occurred while creating category:', error);
        }
      });
  }
}
