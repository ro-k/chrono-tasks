import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {SharedModule} from "../../shared/shared.module";
import {TreeViewExplorerComponent} from "./components/tree-view-explorer/tree-view-explorer.component";



@NgModule({
  declarations: [
    TreeViewExplorerComponent,
  ],
  exports: [
    TreeViewExplorerComponent,
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class TreeViewModule { }
