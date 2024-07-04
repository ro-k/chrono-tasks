import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ParentService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  getAll(): Observable<string[]> {
    return this.http.get<string[]>(this.baseUrl + 'api/parent');
  }
}
