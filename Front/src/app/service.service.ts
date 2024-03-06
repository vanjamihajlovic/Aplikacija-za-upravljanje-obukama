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
  private mentorEndpoint = '/mentor';
  




  constructor(private http: HttpClient) { }

  getUserInfo(userId: string | null): Observable<User> {
    const url = this.baseUrl + userId;
    return this.http.get<User>(url);
  }

  sendFormData(formData: any): Observable<any>{
    return this.http.post<any>(this.baseUrl + 'addMentor', formData);
  }

  sendFormDataCandidate(formData: any): Observable<any>{
    return this.http.post<any>(this.baseUrl + 'addCandidate', formData);
  }

  sendFormMentorCandidates(formData: any): Observable<any>{
    return this.http.post<any>(this.baseUrl + 'candidates', formData);
  }

}
