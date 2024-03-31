import {NgModule, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import {CategoryComponent} from "./components/category/category.component";
import {CategoryFormComponent} from "./components/category-form/category-form.component";
import {CategoryListComponent} from "./components/category-list/category-list.component";
import {SharedModule} from "../../shared/shared.module";
import {ReactiveFormsModule} from "@angular/forms";
import {CategoryStore} from "../../state/stores/category-store";
import {StateModule} from "../../state/state.module";



@NgModule({
    declarations: [
        CategoryComponent,
        CategoryFormComponent,
        CategoryListComponent,
    ],
    exports: [
        CategoryFormComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        ReactiveFormsModule,
        StateModule,
    ]
})
export class CategoriesModule { }
