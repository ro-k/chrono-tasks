export interface Activity {
  activityId: string;
  categoryId: string | null;
  jobId: string | null;
  startTime: Date;
  endTime: Date;
  name: string;
  description: string;
  // BaseModel properties
  createdAt: Date;
  modifiedAt: Date;
  userId: string;
  concurrencyStamp: string;
}

export const defaultActivity: Activity = {
  activityId: "",
  categoryId: "",
  jobId: "",
  startTime: new Date(),
  endTime: new Date(),
  name: "",
  description: "",
  createdAt: new Date(),
  modifiedAt: new Date(),
  userId: "",
  concurrencyStamp: "",
};
