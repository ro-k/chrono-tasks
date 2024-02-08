import {TreeActivity} from "./treeActivity";
import {Job} from "./job";
import {Expandable} from "./expandable";

export interface TreeJob extends Job, Expandable {
  activities: TreeActivity[];
}
