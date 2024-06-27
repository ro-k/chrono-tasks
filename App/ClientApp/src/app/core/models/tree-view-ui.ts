import {ItemType} from "./item-type";

export interface TreeViewUI {
  isExpanded: boolean;
  hasChildren: boolean;
  type: ItemType;
}
