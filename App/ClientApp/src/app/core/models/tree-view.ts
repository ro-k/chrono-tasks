import {TreeViewCategory} from "./tree-view-category";

export interface TreeView {
  categories: TreeViewCategory[];
  uiProps: Map<string, boolean>;
}
