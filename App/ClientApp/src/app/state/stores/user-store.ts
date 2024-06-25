import {createStore, select, withProps} from "@ngneat/elf";
import {Injectable, OnInit} from "@angular/core";
import {AuthService} from "../../features/auth/services/auth.service";
import {catchError, filter, map, Observable, switchMap, tap, lastValueFrom, of} from "rxjs";
import {UserService} from "../../features/user/services/user.service";
import {UserDto} from "../../core/models/user-dto";
import {RegistrationInfo} from "../../core/models/registration-info";
import {HttpErrorResponse} from "@angular/common/http";

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

  user$ = this.store.pipe(select(state => state.user));
  loggedIn$ = this.user$.pipe(filter(user => user != null));
  loggedOut$ = this.user$.pipe(filter(user => user == null));

  constructor(private authService: AuthService, private userService: UserService) {
  }

  refreshUserFromToken(): Promise<void> {
    const token = this.getAuthToken();

    debugger;
    if (token) {
      return lastValueFrom(this.load().pipe(map(()=>undefined)));
    }

    return Promise.resolve();
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
    return this.userService.get().pipe(
      tap(user => {
        this.store.update(state => ({...state, user: user}));
        console.log('User retrieved', user);
      }),
      catchError((error) => {
        console.log(error);
        return of(null);
      })
    );
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
