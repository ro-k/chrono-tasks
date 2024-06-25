import {UserStore} from "./user-store";
import {Store} from "@ngneat/elf";
import {deleteAllEntities} from "@ngneat/elf-entities";

export class ClearableStore {
  store: Store = null!;

  constructor(private userStore: UserStore) {
    this.userStore.loggedOut$.subscribe({
      next: () => this.clear()
    });
  }

  clear(){
    console.log("clearing store")
    this.store?.update(deleteAllEntities());
  }
}
