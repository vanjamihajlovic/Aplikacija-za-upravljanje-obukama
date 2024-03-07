import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Training } from "../model/training";

@Injectable({
    providedIn: 'root'
  })
  export class TrainingService {
  
    baseURL: string = "http://localhost:5275/api/training/";
  
  
    httpOptions = {
      headers: { 'Content-Type': 'application/json' }
    };
  
    constructor(private http: HttpClient) {
     }

    addNewTraining(newTraining: Training): Observable<any> {
      return this.http.post<any>(this.baseURL + 'addTraining', newTraining, this.httpOptions);
    }

    getAllTrainings(): Observable<Training[]> {
      return this.http.get<Training[]>(this.baseURL + 'allTrainings', this.httpOptions);
    }

    getTrainingById(id: string): Observable<Training> {
      return this.http.get<Training>(this.baseURL + id, this.httpOptions);
    }
  }