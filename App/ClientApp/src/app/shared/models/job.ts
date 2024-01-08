export interface Job {
  jobId: string;
  title: string;
  description: string;
  // BaseModel properties
  createdAt: Date;
  modifiedAt: Date;
  userId: string;
  concurrencyStamp: string;
}

export const defaultJob: Job = {
  jobId: "",
  title: "",
  description: "",
  createdAt: new Date(),
  modifiedAt: new Date(),
  userId: "",
  concurrencyStamp: "",
};
