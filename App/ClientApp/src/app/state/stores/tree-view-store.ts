import {Injectable} from "@angular/core";
import {TreeViewState} from "../../core/models/treeViewState";
import {createStore, withProps} from "@ngneat/elf";


@Injectable({
  providedIn: 'root',
})
export class TreeViewStore {
  private store = createStore(
    { name: 'app' },
    withProps<TreeViewState>({ categories: [] })
  );

  // Provide direct access to the store for actions and selectors
  get state() {
    return this.store;
  }
}
