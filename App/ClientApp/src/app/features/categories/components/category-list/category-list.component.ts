import {Component, OnInit} from '@angular/core';
import {Category} from "../../../../core/models/category";
import {CategoryService} from "../../services/category.service";



@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  categories: Category[] = [];
  originalCategories: Category[] = [];
  showAdd = false;

  constructor(private categoryService: CategoryService) {  }

  ngOnInit(): void {
    this.fetchCategories();
  }

  fetchCategories(): void {
    this.categoryService.getCategories().subscribe(
      {
        next: (category) => {
          this.categories = category;
          this.originalCategories = [...category];
        },
        error: console.error
      }
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

  handleFilter(filterTerm:string): void {
    if (!filterTerm) {
      // If no search term, reset categories to original
      this.categories = [...this.originalCategories];
    } else {
      // Filter categories based on the search term
      this.categories = this.originalCategories.filter(category =>
        category.name.toLowerCase().includes(filterTerm.toLowerCase()) ||
        category.description?.toLowerCase().includes(filterTerm.toLowerCase())
      );
    }
  }

  protected readonly console = console;
}
