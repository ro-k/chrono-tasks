import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavMenuComponent} from "./components/nav-menu/nav-menu.component";
import {HomeComponent} from "./components/home/home.component";
import {RouterLink, RouterLinkActive} from "@angular/router";



@NgModule({
  declarations: [
    NavMenuComponent,
    HomeComponent,
  ],
  exports: [
    NavMenuComponent,
    HomeComponent,
  ],
  imports: [
    CommonModule,
    RouterLink,
    RouterLinkActive
  ]
})
export class NavigationModule { }
