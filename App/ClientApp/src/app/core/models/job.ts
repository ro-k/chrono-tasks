export interface Job {
  jobId: string;
  categoryId: string;
  name: string;
  description: string;
  data: string;
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
  data: "",
  createdAt: new Date(),
  modifiedAt: new Date(),
  userId: "",
  concurrencyStamp: "",
};
