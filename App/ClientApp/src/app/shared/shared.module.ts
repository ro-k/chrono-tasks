import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {YesNoComponent} from "./components/yes-no/yes-no.component";
import {FilterInputComponent} from "./components/filter-input/filter-input.component";
import {NothingHereComponent} from "./components/nothing-here/nothing-here.component";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {ListHeaderComponent} from "./components/list-header/list-header.component";
import {BackComponent} from "./components/back/back.component";
import {EditDialogComponent} from "./components/edit-dialog/edit-dialog.component";

@NgModule({
  declarations: [
    YesNoComponent,
    FilterInputComponent,
    NothingHereComponent,
    ListHeaderComponent,
    BackComponent,
    EditDialogComponent
  ],
  exports: [
    YesNoComponent,
    NothingHereComponent,
    FilterInputComponent,
    ListHeaderComponent,
    BackComponent,
    EditDialogComponent
  ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
    ]
})
export class SharedModule { }
