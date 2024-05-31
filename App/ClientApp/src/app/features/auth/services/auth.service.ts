import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {catchError, map, Observable, throwError} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  login(username: string, password: string) {
    return this.http.post<{ access_token: string }>(this.baseUrl + 'api/user/login', { username, password })
      .pipe(
        map(response => {
          debugger;
          localStorage.setItem('access_token', response.access_token);
          return response;
        }),
        catchError(error => {
          console.error('Login failed:', error);
          return throwError(() => new Error('Login failed'));
        })
      );
  }

  register(username: string, password: string, email: string, firstname: string, lastname: string) {
    return this.http.post<{ access_token: string }>(this.baseUrl + `api/user`, { username, password, email, firstname, lastname })
      .pipe(
        map(response => {
          localStorage.setItem('access_token', response.access_token);
        }),
        catchError(error => {
          console.error('Login failed:', error);
          return throwError(() => new Error('Login failed'));
        })
      );
  }

  logout() {
    return this.http.post(this.baseUrl + `api/user/logout`, { }).subscribe({
      next: () => {
        localStorage.clear();
      },
      error: (error) => {
        console.error('Logout failed:', error);
      }
    });
  }
}
