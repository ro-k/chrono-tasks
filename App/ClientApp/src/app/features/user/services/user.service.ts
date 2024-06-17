import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Job} from "../../../core/models/job";
import {UserDto} from "../../../core/models/user-dto";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  get(): Observable<UserDto> {
    return this.http.get<UserDto>(this.baseUrl + 'api/user');
  }
}
