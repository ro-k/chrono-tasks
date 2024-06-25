import {createStore} from "@ngneat/elf";
import {CategoryService} from "../../features/categories/services/category.service";
import {Category} from "../../core/models/category";
import {
  selectAllEntities,
  updateEntities,
  withEntities,
  deleteEntities,
  upsertEntities, deleteAllEntities
} from "@ngneat/elf-entities";
import {Injectable} from "@angular/core";
import {UserStore} from "./user-store";
import {ClearableStore} from "./clearable-store";

@Injectable({
  providedIn: 'root'
})
export class CategoryStore extends ClearableStore {
  store = createStore({ name: 'categories' }, withEntities<Category, 'categoryId'>({idKey: 'categoryId'}));
  categories$ = this.store.pipe(selectAllEntities());

  constructor(private categoryService: CategoryService, userStore: UserStore) {
    super(userStore);
  }

  // load category data
  load() {
    this.categoryService.getAll().subscribe(
      {
        next: (newCategories) => {
          console.log('loading categories');
          this.store.update(upsertEntities(newCategories));
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
        this.store.update(upsertEntities(newCategory));
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
}
