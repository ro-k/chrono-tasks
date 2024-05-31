import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaderResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable()
export class RefreshTokenInterceptor implements HttpInterceptor {
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
            localStorage.setItem('access_token', newToken);
          }
        }
        return event;
      })
    );
  }
}
