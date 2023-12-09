import {Component, OnInit} from '@angular/core';
import {Category} from "../../shared/models/category";
import {CategoryService} from "../../shared/services/category.service";

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
  categories: Category[] = [];

  constructor(private categoryService: CategoryService) {  }
  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(
      { next: (v) => this.categories = v, error: console.error }
    );
  }

  protected readonly alert = alert;

  editCategory(category: Category) {

  }

  deleteCategory(category: Category) {

  }

  addCategory(name: string, description: string) {

  }
}
