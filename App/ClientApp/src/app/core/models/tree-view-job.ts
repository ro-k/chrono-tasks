import {TreeViewActivity} from "./tree-view-activity";
import {Job} from "./job";
import {TreeViewUI} from "./tree-view-ui";
import {Activity} from "./activity";

export type TreeViewJob = Job & JobNodes;
export interface JobNodes extends TreeViewUI {
  jobId: string;
  activities: Activity[];
}
