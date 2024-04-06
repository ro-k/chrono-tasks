import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {JobFormComponent} from "./features/job-form/job-form.component";
import {ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../../shared/shared.module";



@NgModule({
  declarations: [
    JobFormComponent
  ],
  exports: [
    JobFormComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class JobsModule { }
