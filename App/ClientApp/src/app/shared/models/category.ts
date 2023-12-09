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

