export interface Job {
  jobId: string;
  categoryId: string;
  name: string;
  description: string;
  // BaseModel properties
  createdAt: Date;
  modifiedAt: Date;
  userId: string;
  concurrencyStamp: string;
}

export const defaultJob: Job = {
  jobId: "",
  categoryId: "",
  name: "",
  description: "",
  createdAt: new Date(),
  modifiedAt: new Date(),
  userId: "",
  concurrencyStamp: "",
};
