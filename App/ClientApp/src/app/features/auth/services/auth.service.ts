import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {catchError, map, Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  login(username: string, password: string) {
    return this.http.post<any>(`/api/login`, { username, password })
      .pipe(map(user => {

        // todo: store user details and jwt token in local storage to keep user logged in between page refreshes
        return user;
      }));
  }
}
