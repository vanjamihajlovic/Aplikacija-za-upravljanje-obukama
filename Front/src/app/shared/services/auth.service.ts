import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, map, Observable, of } from 'rxjs';
import { Credentials } from '../model/Credentials';
import { JwtHelperService } from '@auth0/angular-jwt';



@Injectable({
    providedIn: 'root'
  })
  export class AuthService {
  
    baseURL: string = "http://localhost:5275/api/account/";
  
    userClaims: any = null;
    private loginSource = new BehaviorSubject<boolean>(false);
    public loginObserver = this.loginSource.asObservable();
  
    httpOptions = {
      headers: { 'Content-Type': 'application/json' }
    };
  
    constructor(private http: HttpClient, private jwtHelper: JwtHelperService) {
      this.userClaims = this.jwtHelper.decodeToken();
      if(this.userClaims)
        this.loginSource.next(true);
     }
  
  
    login(loginRequest: Credentials): Observable<boolean> {
      return this.http.post<any>(this.baseURL + 'login', loginRequest, this.httpOptions).pipe(
        map((res) => {
          localStorage.setItem('token', res.accessToken);
          this.userClaims = this.jwtHelper.decodeToken();
          localStorage.setItem('role', this.userClaims['role']);
          localStorage.setItem('userId', this.userClaims['id']);
          this.loginSource.next(true);
          return true;
        })
      );
    }
  
    logout(): void {
      localStorage.clear();
      this.loginSource.next(false);
    }
  
    getUserRole(): string | null {
      return localStorage.getItem('role');
    }
  
    getUserClaims() : any {
      return this.userClaims;
    }

    getUserId(): string | null{
      return localStorage.getItem('userId')
    }
  
    isLogged(): boolean {
      if (!this.jwtHelper.tokenGetter())
        return false;
      return true;
    }
  }