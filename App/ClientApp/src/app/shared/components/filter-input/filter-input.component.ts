import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-filter-input',
  templateUrl: './filter-input.component.html',
  styleUrls: ['./filter-input.component.css']
})
export class FilterInputComponent {
  filterTerm: string = '';
  @Output() filterEvent = new EventEmitter<string>();
  @Input() itemName = '';

  filterCategories() {
    this.filterEvent.emit(this.filterTerm);
  }

  clearFilter() {
    this.filterTerm = '';
    this.filterCategories();
  }
}
