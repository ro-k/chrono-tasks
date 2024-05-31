import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {Router} from "@angular/router";

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private router: Router) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // // List of endpoints to exclude from token requirement
    const excludedEndpoints = ['/api/user', 'swagger'];

    if (excludedEndpoints.some(url => req.url.includes(url))) {
      return next.handle(req);
    }

    const authToken = localStorage.getItem('access_token');
    if (!authToken) {
      // redirect to login page
      this.router.navigate(['/login']).then(success => {
        if (!success) {
          console.error('Navigation to login failed!');
        }
      });

      return throwError(() => new Error('No auth token'));
    }

    const authReq = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${authToken}`)
    });
    return next.handle(authReq);
  }
}
