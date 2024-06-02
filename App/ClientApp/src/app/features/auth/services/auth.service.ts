import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {catchError, map, throwError} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private accessTokenKey = 'access_token';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  // todo: add authstore
  login(username: string, password: string) {
    return this.http.post<{ access_token: string }>(this.baseUrl + 'api/user/login', { username, password })
      .pipe(
        map(response => {
          this.setAuthToken(response.access_token);
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
          this.setAuthToken(response.access_token);
        }),
        catchError(error => {
          console.error('Login failed:', error);
          return throwError(() => new Error('Login failed'));
        })
      );
  }

  logout() {
    // todo: this is due to refresh in nav bar
    this.removeAuthToken();
    return this.http.post(this.baseUrl + `api/user/logout`, { }).subscribe({
      next: () => {
        // this.removeAuthToken();
      },
      error: (error) => {
        console.error('Logout failed:', error);
      }
    });
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem(this.accessTokenKey);
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
