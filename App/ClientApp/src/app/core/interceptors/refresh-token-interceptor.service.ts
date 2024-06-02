import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaderResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import {AuthService} from "../../features/auth/services/auth.service";

@Injectable()
export class RefreshTokenInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          // handle 401's, refresh token or redirect to login?
        }
        return throwError(() => error);
      }),
      map(event => {
        if (event instanceof HttpHeaderResponse) {
          const newToken = event.headers.get('new-token');
          if (newToken) {
            this.authService.setAuthToken(newToken);
          }
        }
        return event;
      })
    );
  }
}
