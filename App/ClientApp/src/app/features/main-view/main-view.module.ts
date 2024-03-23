import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ContentItemComponent} from "./components/content-item/content-item.component";
import {ContentPaneComponent} from "./components/content-pane/content-pane.component";
import {TransformCategoryPipe} from "./pipes/transform-category.pipe";



@NgModule({
  declarations: [
    ContentItemComponent,
    ContentPaneComponent,
    TransformCategoryPipe
  ],
  imports: [
    CommonModule
  ]
})
export class MainViewModule { }
