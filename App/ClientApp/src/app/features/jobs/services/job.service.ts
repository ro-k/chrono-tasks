import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {catchError, map, Observable, throwError} from "rxjs";
import {Job} from "../../../core/models/job";

@Injectable({
  providedIn: 'root'
})
export class JobService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  getAll(): Observable<Job[]> {
    return this.http.get<Job[]>(this.baseUrl + 'api/job');
  }

  getByCategory(categoryId: string): Observable<Job[]> {
    return this.http.get<Job[]>(this.baseUrl + `api/job/category/${categoryId}`);
  }

  get(jobId: string): Observable<Job> {
    return this.http.get<Job>(this.baseUrl + `api/job/${jobId}`);
  }

  delete(job: Job): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}api/job/${job.jobId}`)
      .pipe(catchError(this.handleError));
  }

  create(job: Job): Observable<Job> {
    return this.http.post<Job>(`${this.baseUrl}api/job/`,
      {name: job.name, description: job.description, categoryId: job.categoryId})
      .pipe(map(x => x), catchError(this.handleError));
  }

  update(job: Job): Observable<Job> {
    return this.http.put<Job>(`${this.baseUrl}api/job/`,
      {jobId: job.jobId, categoryId: job.categoryId, name: job.name, description: job.description, concurrencyStamp: job.concurrencyStamp, })
      .pipe(map(x => x), catchError(this.handleError));
  }

  private handleError(error: any) {
    // logging the error or displaying a message?
    console.error(error);
    return throwError(() => error);
  }
}
