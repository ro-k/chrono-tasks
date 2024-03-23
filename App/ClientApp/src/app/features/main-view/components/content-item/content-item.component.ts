import {Component, EventEmitter, Input, Output} from '@angular/core';
import {TreeViewStore} from "../../../../state/stores/tree-view-store";
import {ContentViewItem} from "../../../../core/models/content-view-item";
import {ItemType} from "../../../../core/models/item-type";

@Component({
  selector: 'app-content-item',
  templateUrl: './content-item.component.html',
  styleUrl: './content-item.component.css'
})
export class ContentItemComponent {
  @Input() item!: ContentViewItem;
  @Output() clicked = new EventEmitter<ContentViewItem>();
  hovered: boolean = false;

  constructor(private treeViewStore: TreeViewStore) {
  }

  onRowClick(): void {
     console.log('item clicked');
     this.clicked.emit(this.item);
  }

  protected readonly ItemType = ItemType;
}
