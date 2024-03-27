import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {YesNoComponent} from "./components/yes-no/yes-no.component";
import {FilterInputComponent} from "./components/filter-input/filter-input.component";
import {NothingHereComponent} from "./components/nothing-here/nothing-here.component";
import {FormsModule} from "@angular/forms";
import {ListHeaderComponent} from "./components/list-header/list-header.component";
import {BackComponent} from "./components/back/back.component";

@NgModule({
  declarations: [
    YesNoComponent,
    FilterInputComponent,
    NothingHereComponent,
    ListHeaderComponent,
    BackComponent
  ],
  exports: [
    YesNoComponent,
    NothingHereComponent,
    FilterInputComponent,
    ListHeaderComponent,
    BackComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
  ]
})
export class SharedModule { }
