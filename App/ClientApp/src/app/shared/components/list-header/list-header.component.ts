import {Component, EventEmitter, Input, Output} from '@angular/core';
import {ItemType} from "../../../core/models/item-type";

@Component({
  selector: 'app-list-header',
  templateUrl: './list-header.component.html',
  styleUrl: './list-header.component.scss'
})
export class ListHeaderComponent {
  @Output() handleFilterEvent = new EventEmitter<string>;
  @Output() addEvent = new EventEmitter<ItemType>;
  @Input() itemTypes: Set<ItemType> = new Set<ItemType>();
  @Input() showAdd = true;
  @Input() showFilter = true;
  protected readonly ItemType = ItemType;
}
