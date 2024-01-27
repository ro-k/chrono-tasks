import {Item} from "./item";

export interface Folder {
  folderId: string;
  name: string;
  isExpanded: boolean;
  items: Item[];
  subFolders: Folder[];
}
