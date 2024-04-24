import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ActivityFormComponent} from "./components/activity-form/activity-form.component";
import {ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../../shared/shared.module";



@NgModule({
  declarations: [
    ActivityFormComponent
  ],
  exports: [
    ActivityFormComponent
  ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        SharedModule,
    ]
})
export class ActivitiesModule { }
