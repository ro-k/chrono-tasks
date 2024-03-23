import {TreeViewCategory} from "./tree-view-category";
import {ContentViewItem} from "./content-view-item";

export interface TreeView {
  categories: TreeViewCategory[];
  navigationStack: ContentViewItem[];
}
