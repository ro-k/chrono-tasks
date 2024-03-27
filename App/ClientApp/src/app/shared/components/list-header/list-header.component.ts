import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-list-header',
  templateUrl: './list-header.component.html',
  styleUrl: './list-header.component.css'
})
export class ListHeaderComponent {
  @Output() handleFilterEvent = new EventEmitter<string>;
  @Output() addEvent = new EventEmitter<void>;
  @Output() backEvent = new EventEmitter<void>;
  @Input() addText: string = '';
  @Input() showAdd = true;
  @Input() showFilter = true;
  @Input() showBack = true;
}
