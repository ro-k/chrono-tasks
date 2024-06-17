import {createStore, select, withProps} from "@ngneat/elf";
import {Injectable} from "@angular/core";
import {AuthService} from "../../features/auth/services/auth.service";
import {catchError, map, Observable, switchMap, tap} from "rxjs";
import {UserService} from "../../features/user/services/user.service";
import {UserDto} from "../../core/models/user-dto";
import {RegistrationInfo} from "../../core/models/registration-info";

export class UserState {
  user: UserDto | undefined;
}

@Injectable({
  providedIn: 'root'
})
export class UserStore {
  private store = createStore(
    { name: 'auth' },
    withProps<UserState>({user: undefined}),
  );
  private accessTokenKey = 'access_token';

//  user$ = this.store.pipe(tap (s => s));
  user$ = this.store.pipe(select(state => state.user));

  constructor(private authService: AuthService, private userService: UserService) {
  }

  isLoggedIn(): boolean {
    return (this.store.getValue() != null);
  }

  login(username: string, password: string) : Observable<any> {
    return this.authService.login(username, password).pipe(
      tap(response => {
        console.log('Logged in');
        this.setAuthToken(response.access_token);
      }),
      switchMap(response => {
        return this.userService.get().pipe(
          tap(user => {
            this.store.update(state => ({...state, user: user}));
            console.log('User retrieved', user);
          })
        );
      }),
      catchError(error => {
        console.error('Login failed or cannot retrieve user', error);
        throw error;
      })
    );
  }

  // load user data
  load() {
    // todo: could separate login and load
  }

  // add user
  register(registrationInfo: RegistrationInfo) {
    return this.authService.register(registrationInfo).pipe(
      switchMap(response => {
        console.log('Signed up, logged in');
        this.setAuthToken(response.access_token);

        return this.userService.get().pipe(
          tap(user => {
            this.store.update(state => ({...state, user: user}));
            console.log('User retrieved', user);
          })
        );
      }),
      catchError(error => {
        console.error('Registration failed or cannot retrieve user', error);
        throw error;
      })
    );
  }

  logout() {
    return this.authService.logout()
      .pipe(
        map(response =>{
          this.removeAuthToken();
          this.store.update(state => ({...state, user: undefined}));
          // todo: clear other stores
        }),
        catchError(error => {
          console.error('Logout failed:', error);
          throw error;
        })
      );
}

  // Update an existing user
  update(user: UserDto) {
    // todo
  }

  // Delete a user
  delete(user: UserDto) {
    // todo
  }

  getAuthToken(): string | null {
    return localStorage.getItem(this.accessTokenKey);
  }

  setAuthToken(token: string): void {
    localStorage.setItem(this.accessTokenKey, token);
  }

  removeAuthToken(): void {
    localStorage.removeItem(this.accessTokenKey);
  }
}
