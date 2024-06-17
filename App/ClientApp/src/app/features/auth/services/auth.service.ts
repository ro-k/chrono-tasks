import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {catchError, map, throwError} from "rxjs";
import {RegistrationInfo} from "../../../core/models/registration-info";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  // todo: add authstore
  login(username: string, password: string) {
    return this.http.post<{ access_token: string }>(this.baseUrl + 'api/user/login', { username, password });
  }

  register(registrationInfo: RegistrationInfo) {
    return this.http.post<{ access_token: string }>(this.baseUrl + `api/user`, registrationInfo);
  }

  logout() {
    return this.http.post(this.baseUrl + `api/user/logout`, { });
  }
}
