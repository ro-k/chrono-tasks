import { BrowserModule } from '@angular/platform-browser';
import {APP_ID, APP_INITIALIZER, NgModule} from '@angular/core';
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
import {AuthModule} from "./features/auth/auth.module";
import {LoginComponent} from "./features/auth/components/login/login.component";
import {SignupComponent} from "./features/auth/components/signup/signup.component";
import {UserService} from "./features/user/services/user.service";
import {UserStore} from "./state/stores/user-store";
import {ParentsModule} from "./features/parents/parents.module";

export function initializeApp(userStore: UserStore): () => Promise<void> {
  // todo: move to init service with other store init
  return (): Promise<void> => userStore.refreshUserFromToken();
}

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AuthModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    ParentsModule,
    CoreModule,
    NavigationModule,
    CategoriesModule,
    TreeViewModule,
    MainViewModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'category', component: CategoryListComponent},
      {path: 'content', component: ContentPaneComponent},
      {path: 'login', component: LoginComponent},
      {path: 'signup', component: SignupComponent},
    ]),
  ],
  providers: [
    {provide: APP_ID, useValue: 'ng-cli-universal'},
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [UserStore],
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
