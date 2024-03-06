import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../model/User";
import { Observable } from "rxjs";




@Injectable({
    providedIn: 'root'
  })
  export class UserService {
  
    baseURL: string = "http://localhost:5275/api/user/";
  
  
    httpOptions = {
      headers: { 'Content-Type': 'application/json' }
    };
  
    constructor(private http: HttpClient) {
     }

    getAllMentors(): Observable<User[]> {
      return this.http.get<any>(this.baseURL + 'getAllMentors');
    }

    getAllCandidates(): Observable<User[]> {
        return this.http.get<any>(this.baseURL + 'getAllCandidates');
      }
  }