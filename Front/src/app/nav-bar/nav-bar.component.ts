import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatExpansionModule } from '@angular/material/expansion';
import { AuthService } from '../shared/services/auth.service';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ServiceService } from '../service.service';
import { User } from '../shared/model/User';
import { Mentor } from '../shared/model/Mentor';

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
  
  ngOnInit(): void {
    this.authService.loginObserver.subscribe((val) => {
      this.isLogged = val;
      console.log(this.isLogged)
      if(this.isLogged) {
        this.userRole = this.authService.getUserRole();
        this.userId = this.authService.getUserId();
      }
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
        if (this.user.role == '1'){  this.user.role= "Admin"};
        console.log(this.user);
      },
      (error) => {
        console.error('Error fetching products:', error);
                alert('Error: ' + error);
      }
    );
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
