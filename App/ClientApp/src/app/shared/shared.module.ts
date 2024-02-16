import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {YesNoComponent} from "./components/yes-no/yes-no.component";
import {FilterInputComponent} from "./components/filter-input/filter-input.component";
import {NothingHereComponent} from "./components/nothing-here/nothing-here.component";
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    YesNoComponent,
    FilterInputComponent,
    NothingHereComponent,
  ],
  exports: [
    YesNoComponent,
    NothingHereComponent,
    FilterInputComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
  ]
})
export class SharedModule { }
