export interface Category {
  categoryId: string;
  name: string;
  description: string | null;
  createdAt: Date;
  modifiedAt: Date;
  userId: string;
  concurrencyStamp: string;
  status: number;
}

export const defaultCategory: Category = {
  categoryId: "",
  concurrencyStamp: "",
  createdAt: new Date(),
  description: null,
  modifiedAt: new Date(),
  name: "",
  status: 0,
  userId: ""
};

