import {TreeActivity} from "./treeActivity";
import {Category} from "./category";
import {Expandable} from "./expandable";
import {TreeJob} from "./treeJob";

export interface TreeCategory extends Category, Expandable {
  activities: TreeActivity[];
  jobs: TreeJob[];
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
