import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { SharedModule } from "./shared/shared.module";
import { CoreModule } from "./core/core.module";
import { NavigationModule } from "./features/navigation/navigation.module";
import { HomeComponent } from "./features/navigation/components/home/home.component";
import { CategoriesModule } from "./features/categories/categories.module";
import { CategoryListComponent } from "./features/categories/components/category-list/category-list.component";
import {TreeViewModule} from "./features/tree-view/tree-view.module";

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    CoreModule,
    NavigationModule,
    CategoriesModule,
    TreeViewModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'category', component: CategoryListComponent},
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
