import {Status} from "./status";

export interface UserDto {
  userId: string;
  username: string;
  email: string;
  emailConfirmed: boolean;
  phoneNumber: string;
  phoneNumberConfirmed: boolean;
  twoFactorEnabled: boolean;
  profilePictureMediaId: string | null;
  firstName: string;
  lastName: string;
  createdAt: Date;
  modifiedAt: Date;
  concurrencyStamp: string;
  status: Status;
}
