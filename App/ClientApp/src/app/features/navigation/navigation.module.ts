import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavMenuComponent} from "./components/nav-menu/nav-menu.component";
import {HomeComponent} from "./components/home/home.component";
import {RouterLink, RouterLinkActive} from "@angular/router";
import {LoginStateComponent} from "./components/login-state/login-state.component";
import {BrowserModule} from "@angular/platform-browser";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";



@NgModule({
  declarations: [
    NavMenuComponent,
    HomeComponent,
    LoginStateComponent
  ],
  exports: [
    NavMenuComponent,
    HomeComponent,
    LoginStateComponent
  ],
  imports: [
    CommonModule,
    RouterLink,
    RouterLinkActive,
    BrowserModule,
    BrowserAnimationsModule
  ]
})
export class NavigationModule { }
