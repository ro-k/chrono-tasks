import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ContentItemComponent} from "./components/content-item/content-item.component";
import {ContentPaneComponent} from "./components/content-pane/content-pane.component";
import {SharedModule} from "../../shared/shared.module";



@NgModule({
  declarations: [
    ContentItemComponent,
    ContentPaneComponent,
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class MainViewModule { }
