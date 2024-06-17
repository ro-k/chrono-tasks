import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {UserDto} from "./core/models/user-dto";
import {UserStore} from "./state/stores/user-store";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Task';
  isLoggedIn = false;
  user$: Observable<UserDto | undefined>;

  constructor(userStore: UserStore) {
    this.user$ = userStore.user$;

    userStore.user$.subscribe(user => {
      this.isLoggedIn = (user != null);
    });
  }
}
