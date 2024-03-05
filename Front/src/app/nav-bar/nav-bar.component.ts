import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatExpansionModule } from '@angular/material/expansion';
import { AuthService } from '../shared/services/auth.service';
import { Router } from '@angular/router';

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
  constructor(private formbuilder: FormBuilder, private authService: AuthService, private router: Router){}
  
  toppingList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];
  ngOnInit(): void {
    this.toppings = new FormControl();
    this.authService.loginObserver.subscribe((val) => {
      this.isLogged = val;
      console.log(this.isLogged)
      if(this.isLogged) {
        this.userRole = this.authService.getUserRole();
      }
    });
  }  

  logout(): void {
    this.authService.logout();
    this.userRole = '';
    this.router.navigate(['/']);
  }
}
