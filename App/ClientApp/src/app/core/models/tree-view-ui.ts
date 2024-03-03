export interface TreeViewUI {
  isExpanded: boolean;
  type: TreeViewItemType;
}

export enum TreeViewItemType {
  Category = 1,
  Job,
}
