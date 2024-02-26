import {TreeViewActivity} from "./tree-view-activity";
import {Job} from "./job";
import {Expandable} from "./expandable";

export interface TreeViewJob extends Expandable {
  entity: Job;
  activities: TreeViewActivity[];
}
