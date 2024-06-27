import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {catchError, map, Observable, throwError} from "rxjs";
import {Category} from "../../../core/models/category";

@Injectable({
  providedIn: 'root'
})
export class CategoryService  {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  // todo: switch all single use Observables to Promises
  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'api/category').pipe(catchError(this.handleError));
  }

  delete(category: Category): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}api/category/${category.categoryId}`)
      .pipe(catchError(this.handleError));
  }

  create(category: Category): Observable<Category> {
    return this.http.post<Category>(`${this.baseUrl}api/category/`,
      {name: category.name, description: category.description})
      .pipe(map(x => x), catchError(this.handleError));
  }

  update(category: Category): Observable<Category> {
    return this.http.put<Category>(`${this.baseUrl}api/category/`,
      {categoryId: category.categoryId, name: category.name, description: category.description, concurrencyStamp: category.concurrencyStamp})
      .pipe(map(x => x), catchError(this.handleError));
  }

  private handleError(error: any) {
    // logging the error or displaying a message?
    console.error(error);
    return throwError(() => error);
  }
}
