import {TreeViewCategory} from "./tree-view-category";

export interface TreeView {
  categories: TreeViewCategory[];
  parentIds: Set<string>;
}
