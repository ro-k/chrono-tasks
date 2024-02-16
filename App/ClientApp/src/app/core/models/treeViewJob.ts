import {TreeViewActivity} from "./treeViewActivity";
import {Job} from "./job";
import {Expandable} from "./expandable";

export interface TreeViewJob extends Job, Expandable {
  activities: TreeViewActivity[];
}
