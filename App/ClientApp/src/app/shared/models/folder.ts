import {Item} from "./item";

export interface Folder {
  folderId: string;
  name: string;
  items: Item[];
  subFolders: Folder[];
}
