import {createStore} from "@ngneat/elf";
import {CategoryService} from "../../features/categories/services/category.service";
import {Category} from "../../core/models/category";
import {addEntities, selectAllEntities, updateEntities, withEntities, deleteEntities} from "@ngneat/elf-entities";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class CategoryStore {
  private store = createStore({ name: 'categories' }, withEntities<Category, 'categoryId'>({idKey: 'categoryId'}));
  categories$ = this.store.pipe(selectAllEntities());

  constructor(private categoryService: CategoryService) {
  }

  // load category data
  load() {
    this.categoryService.get().subscribe(
      {
        next: (newCategories) => {
          console.log('loading categories');
          newCategories.forEach(x => console.log(x));
          console.log(this.store);
          this.store.forEach(x => console.log(x));
          this.store.update(addEntities(newCategories));
        },
        error: (error) => {
          console.error('Failed to load categories', error);
        }
      }
    );
  }

  // add category
  add(category: Category) {
    this.categoryService.create(category).subscribe({
      next: (newCategory: Category) => {
        this.store.update(addEntities(category));
      },
      error: (error) => {
        console.error('Failed to add category', error);
      }
    });
  }

  // Update an existing category
  update(category: Category) {
    this.categoryService.update(category).subscribe({
      next: (updatedCategory: Category) => {
        this.store.update(updateEntities(updatedCategory.categoryId, updatedCategory));
      },
      error: (error) => {
        console.error('Failed to update category', error);
      }
    });
  }

  // Delete a category
  delete(category: Category) {
    this.categoryService.delete(category).subscribe({
      next: () => {
        this.store.update(deleteEntities(category.categoryId));
      },
      error: (error) => {
        console.error('Failed to delete category', error);
      }
    });
  }

  // Selector to get all categories
  getAll() {
    return this.store.pipe(selectAllEntities());
  }
}
