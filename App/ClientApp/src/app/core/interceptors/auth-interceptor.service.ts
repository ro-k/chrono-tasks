import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse,
  HttpHeaderResponse
} from '@angular/common/http';
import {catchError, map, Observable, throwError} from 'rxjs';
import {Router} from "@angular/router";
import {UserStore} from "../../state/stores/user-store";

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private router: Router, private userStore: UserStore) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // List of endpoints to exclude from token requirement
    const excludedEndpoints = ['/api/user/login', 'swagger','/home'];
    const excludedPostEndpoints = ['/api/user/'];

    if (excludedEndpoints.some(url => req.url.includes(url))) {
      return next.handle(req);
    }

    if(req.method === 'POST' && excludedPostEndpoints.some(url => req.url.includes(url))) {
      return next.handle(req);
    }

    if (!this.userStore.isLoggedIn() && !this.userStore.getAuthToken()) {
      this.router.navigate(['/login']).then(success => {
        if (!success) {
          console.error('Navigation to login failed!');
        }
      });

      return throwError(() => new Error('No auth token'));
    }

    const authToken = this.userStore.getAuthToken();
    const authReq = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${authToken}`)
    });
    // return next.handle(authReq);
    return next.handle(authReq).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          this.router.navigate(['/login']).then(success => {
            if (!success) {
              console.error('Navigation to login failed!');
            }
          });
        }
        return throwError(() => error);
      }),
      map(event => {
        if (event instanceof HttpHeaderResponse) {
          const newToken = event.headers.get('new-token');
          if (newToken) {
            this.userStore.setAuthToken(newToken);
          }
        }
        return event;
      })
    );
  }
}
