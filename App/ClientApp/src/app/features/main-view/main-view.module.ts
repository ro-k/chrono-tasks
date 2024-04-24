import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ContentItemComponent} from "./components/content-item/content-item.component";
import {ContentPaneComponent} from "./components/content-pane/content-pane.component";
import {SharedModule} from "../../shared/shared.module";
import {CategoriesModule} from "../categories/categories.module";
import {JobsModule} from "../jobs/jobs.module";
import {ActivitiesModule} from "../activities/activities.module";



@NgModule({
  declarations: [
    ContentItemComponent,
    ContentPaneComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    CategoriesModule,
    JobsModule,
    ActivitiesModule
  ]
})
export class MainViewModule { }
