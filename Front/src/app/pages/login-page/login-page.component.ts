import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../shared/services/auth.service';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Credentials } from '../../shared/model/credentials';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent implements OnInit {

  public credentials = new Credentials();
  public error: boolean = false;
  public admin: any;

  constructor(private authService: AuthService, private router: Router, private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
  }

  logIn(): void {
    this.authService.login(this.credentials).subscribe(res => {
      if(this.authService.getUserRole() == 'ADMINISTRATOR') 
      {
        this.router.navigate(['/home-admin']);
      }else if(this.authService.getUserRole() == 'MENTOR') {
        this.router.navigate(['/home-mentor']);
      }else if(this.authService.getUserRole() == 'CANDIDATE') {
        this.router.navigate(['/home-candidate']);
      }
      
    },
    error => this.error = true);
  }
}