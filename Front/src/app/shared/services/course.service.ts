import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Course } from "../model/course";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
  export class CourseService {
  
    baseURL: string = "http://localhost:5275/api/course/";
  
  
    httpOptions = {
      headers: { 'Content-Type': 'application/json' }
    };
  
    constructor(private http: HttpClient) {
     }

    getAllCoursesByTrainingId(id: string): Observable<Course[]> {
      return this.http.get<Course[]>(this.baseURL + 'getAllByTraining/'+ id, this.httpOptions);
    }
  }