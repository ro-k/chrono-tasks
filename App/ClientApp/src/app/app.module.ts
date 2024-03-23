import { BrowserModule } from '@angular/platform-browser';
import {APP_ID, NgModule} from '@angular/core';
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
import {MainViewModule} from "./features/main-view/main-view.module";
import {ContentPaneComponent} from "./features/main-view/components/content-pane/content-pane.component";

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    CoreModule,
    NavigationModule,
    CategoriesModule,
    TreeViewModule,
    MainViewModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'category', component: CategoryListComponent},
      {path: 'content', component: ContentPaneComponent},
    ]),
  ],
  providers: [
    {provide: APP_ID, useValue: 'ng-cli-universal'}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
