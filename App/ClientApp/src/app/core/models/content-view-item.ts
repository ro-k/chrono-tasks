import {ItemType} from "./item-type";

export interface ContentViewItem {
  id: string;
  name: string;
  description: string;
  createdAt: Date;
  modifiedAt: Date;
  type: ItemType;
}
