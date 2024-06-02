import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {Router} from "@angular/router";
import {AuthService} from "../../features/auth/services/auth.service";

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private router: Router, private authService: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // // List of endpoints to exclude from token requirement
    const excludedEndpoints = ['/api/user', 'swagger','/home'];

    if (excludedEndpoints.some(url => req.url.includes(url))) {
      return next.handle(req);
    }

    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']).then(success => {
        if (!success) {
          console.error('Navigation to login failed!');
        }
      });

      return throwError(() => new Error('No auth token'));
    }

    const authToken = this.authService.getAuthToken();
    const authReq = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${authToken}`)
    });
    return next.handle(authReq);
  }
}
