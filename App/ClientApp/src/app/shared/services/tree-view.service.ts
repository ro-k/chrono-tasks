import {Inject, Injectable, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Category} from "../models/category";
import {catchError, map, Observable, throwError} from "rxjs";
import {AppState} from "../models/appState";


@Injectable({
  providedIn: 'root'
})
export class TreeViewService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {  }

  // getTreeView(): Observable<TreeView> {
  //   return this.http.get<TreeView>(this.baseUrl + 'api/treeview');
  // }

  getTreeView(): Observable<AppState> {
    return this.http.get<AppState>(this.baseUrl + 'api/treeview');
  }
}
