import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { throwError } from 'rxjs';
import { User } from './shared/model/User';



@Injectable({
  providedIn: 'root'
})


export class ServiceService {
  private baseUrl = 'http://localhost:5275/api/account/';
  private userInfoEndpoint = '/info';




  constructor(private http: HttpClient) { }

  getUserInfo(userId: string | null): Observable<User> {
    const url = this.baseUrl + userId;
    return this.http.get<User>(url);
  }

}
