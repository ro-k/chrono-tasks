import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CategoryComponent} from "./components/category/category.component";
import {CategoryFormComponent} from "./components/category-form/category-form.component";
import {CategoryListComponent} from "./components/category-list/category-list.component";
import {SharedModule} from "../../shared/shared.module";
import {ReactiveFormsModule} from "@angular/forms";



@NgModule({
  declarations: [
    CategoryComponent,
    CategoryFormComponent,
    CategoryListComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
  ]
})
export class CategoriesModule { }
