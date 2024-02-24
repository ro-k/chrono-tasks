import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {catchError, map, Observable, throwError} from "rxjs";
import {Activity} from "../../../core/models/activity";

@Injectable({
  providedIn: 'root'
})
export class ActivityService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  create(activity: Activity): Observable<Activity> {
    return this.http.post<Activity>(`${this.baseUrl}api/activity/`,
      {name: activity.name, description: activity.description, startTime: activity.startTime, endTime: activity.endTime})
      .pipe(map(x => x), catchError(this.handleError));
  }

  update(activity: Activity): Observable<Activity> {
    return this.http.put<Activity>(`${this.baseUrl}api/activity/`,
      {activityId: activity.activityId, name: activity.name, description: activity.description, startTime: activity.startTime, endTime: activity.endTime, concurrencyStamp: activity.concurrencyStamp, })
      .pipe(map(x => x), catchError(this.handleError));
  }

  getAll(): Observable<Activity[]> {
    return this.http.get<Activity[]>(this.baseUrl + `api/activity/`);
  }

  getByCategory(categoryId: string): Observable<Activity[]> {
    return this.http.get<Activity[]>(this.baseUrl + `api/activity/category/${categoryId}`);
  }

  delete(activity: Activity): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}api/activity/${activity.activityId}`)
      .pipe(catchError(this.handleError));
  }

  clearCategory(activityId: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}api/activity/${activityId}/category`)
      .pipe(catchError(this.handleError));
  }

  getByJob(jobId: string): Observable<Activity[]> {
    return this.http.get<Activity[]>(this.baseUrl + `api/activity/job/${jobId}`);
  }

  get(activityId: string): Observable<Activity> {
    return this.http.get<Activity>(this.baseUrl + `api/activity/${activityId}`);
  }

  clearJob(activityId: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}api/activity/${activityId}/job`)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: any) {
    // logging the error or displaying a message?
    console.error(error);
    return throwError(() => error);
  }
}
