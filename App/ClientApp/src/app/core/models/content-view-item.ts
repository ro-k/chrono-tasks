import {ItemType} from "./item-type";

export interface ContentViewItem {
  id: string;
  name: string;
  description: string;
  createdAt: Date|null;
  modifiedAt: Date|null;
  type: ItemType;
}
