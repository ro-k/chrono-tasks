export interface Media {
  mediaId: string;
  originalFilename: string;
  extension: string;
  mimeType: string;
  size: number;
  storagePath: string;
  hash: string;
  metadata: string;
  // BaseModel properties
  createdAt: Date;
  modifiedAt: Date;
  userId: string;
  concurrencyStamp: string;
}

export const defaultMedia: Media = {
  mediaId: "",
  originalFilename: "",
  extension: "",
  mimeType: "",
  size: 0,
  storagePath: "",
  hash: "",
  metadata: "",
  createdAt: new Date(),
  modifiedAt: new Date(),
  userId: "",
  concurrencyStamp: "",
};
