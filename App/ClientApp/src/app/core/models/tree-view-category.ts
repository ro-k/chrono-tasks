import {Category} from "./category";
import {TreeViewUI} from "./tree-view-ui";
import {Activity} from "./activity";
import {TreeViewJob} from "./tree-view-job";


export type TreeViewCategory = Category & CategoryNodes;
export interface CategoryNodes extends TreeViewUI {
  categoryId: string;
  activities: Activity[];
  jobs: TreeViewJob[];
}


// export const treeCategory: TreeCategory = {
//   categoryId: "",
//   concurrencyStamp: "",
//   createdAt: new Date(),
//   description: "",
//   isExpanded: false,
//   items: [],
//   jobs: [],
//   modifiedAt: new Date(),
//   name: "",
//   status: 0,
//   userId: ""
//
// };
//
// export const treeActivity: TreeActivity = {
//   activityId: "",
//   concurrencyStamp: "",
//   createdAt: new Date(),
//   description: "",
//   endTime: new Date(),
//   modifiedAt: new Date(),
//   name: "",
//   startTime: new Date(),
//   userId: ""
//
// };
//
// export const treeJob: TreeJob = {
//   activities: [],
//   concurrencyStamp: "",
//   createdAt: new Date(),
//   description: "",
//   isExpanded: false,
//   jobId: "",
//   modifiedAt: new Date(),
//   title: "",
//   userId: ""
//
// };
