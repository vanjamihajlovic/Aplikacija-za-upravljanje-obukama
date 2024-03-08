import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatExpansionModule } from '@angular/material/expansion';
import { AuthService } from '../shared/services/auth.service';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ServiceService } from '../service.service';
import { User } from '../shared/model/User';
import { Mentor } from '../shared/model/mentor';
import { Candidate } from '../shared/model/candidate';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent implements OnInit {
  formValue !: FormGroup;
  toppings !: FormControl;
  isLogged: boolean = false;
  userRole: string | null = '';
  userId : string | null = '';
  formData !: FormGroup;


  constructor(private formbuilder: FormBuilder, private authService: AuthService, private router: Router,  private _service: ServiceService){
  
  }
  user : User = new User();
  mentor: Mentor = new Mentor();
  candidate: Candidate = new Candidate();
   
  ngOnInit(): void {
    this.authService.loginObserver.subscribe((val) => {
      this.isLogged = val;
      if(this.isLogged) {
        this.userRole = this.authService.getUserRole();
        this.userId = this.authService.getUserId();
      }
    }, error=> {
      console.log(error);
    });
    this.fetchProducts();

    this.formData = this.formbuilder.group({
      name: [''],
      surname: [''],
      email: [''],
      password: [''],
      address: ['']
    });
  }  
  

  fetchProducts() {
    console.log(this.userId)
    this._service.getUserInfo(this.userId).subscribe(
      (data) => {
        this.user = data;
        console.log(this.user.role)
        if (this.user.role == '1'){  this.user.role= "Admin"}
        else if (this.user.role == '2'){  this.user.role= "Mentor"}
        else {this.user.role = "Candidate"};
        console.log(this.user);
      },
      (error) => {
        console.error('Error fetching products:', error);
      }
    );
  }

  onSendCandidate() {
    if (this.formData && this.formData.valid) {
      console.log(this.candidate);
      this._service.sendFormDataCandidate(this.candidate).subscribe(
        response => {
          console.log(response);
        },
        error => {
          console.error(error);
        }
      );
    } else {
      console.log('Forma nije validna');
    }
  }

 
onSendMentor() {
  if (this.formData && this.formData.valid) {
    console.log(this.mentor);
    this._service.sendFormData(this.mentor).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.error(error);
      }
    );
  } else {
    console.log('Forma nije validna');
  }
}

  
  logout(): void {
    this.authService.logout();
    this.userRole = '';
    this.router.navigate(['/']);
  }
}
