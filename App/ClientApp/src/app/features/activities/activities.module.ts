import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ActivityFormComponent} from "./components/activity-form/activity-form.component";



@NgModule({
  declarations: [
    ActivityFormComponent
  ],
  exports: [
    ActivityFormComponent
  ],
  imports: [
    CommonModule,
  ]
})
export class ActivitiesModule { }
