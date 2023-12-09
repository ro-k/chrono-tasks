import {Inject, Injectable, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Category} from "../models/category";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class CategoryService  {
  public categories: Category[] = [];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'api/category');
  }

  deleteCategory(category: Category): Observable<void> {
    return this.http.
  }
}
