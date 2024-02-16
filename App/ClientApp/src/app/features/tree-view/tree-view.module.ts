import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {TreeViewMenuComponent} from "./components/tree-view-menu/tree-view-menu.component";
import {SharedModule} from "../../shared/shared.module";



@NgModule({
  declarations: [
    TreeViewMenuComponent,
  ],
  exports: [
    TreeViewMenuComponent,
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class TreeViewModule { }
