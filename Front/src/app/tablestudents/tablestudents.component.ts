import { Component, OnInit } from '@angular/core';
import { Form, FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { ServiceService } from '../service.service';
import { TableCandidates } from '../shared/model/tablecandidates';
import { Candidate } from '../shared/model/candidate';

@Component({
  selector: 'app-tablestudents',
  templateUrl: './tablestudents.component.html',
  styleUrl: './tablestudents.component.css'
})
export class TablestudentsComponent implements OnInit {

  formData !: FormGroup;
  candidates !: Candidate[];
 // candidate: Candidate = new Candidate();
  items: any[] = [
    { name: 'Candidate 1', feedback: "Dobar", ocena: 5, duration: '01.01.2024' },
    { name: 'Candidate 2', feedback: "Dobar", ocena: 5, duration: '01.01.2024' },
    { name: 'Candidate 3', feedback: "Dobar", ocena: 5, duration: '01.01.2024' },
    { name: 'Candidate 4', feedback: 'Odličan', ocena: 4.5, duration: '15.02.2024' },
    { name: 'Candidate 5', feedback: 'Prosečan', ocena: 3, duration: '30.03.2024' }
  ];
  isDropdownOpen: boolean[] = [];
  constructor(private formbuilder:FormBuilder, private service:ServiceService ) {
    this.isDropdownOpen = [];
  }

  tablecandidates: TableCandidates = new TableCandidates();
  ngOnInit(): void {
    
  }
  
  ratings = [
    { value: 1, viewValue: '1' },
    { value: 2, viewValue: '2' },
    { value: 3, viewValue: '3' },
    { value: 4, viewValue: '4' },
    { value: 5, viewValue: '5' }
  ];
  

  toggleDropdown(index: number): void {
    this.isDropdownOpen[index] = !this.isDropdownOpen[index];
  }


  saveItem(){
      console.log(this.tablecandidates);
      this.service.sendFormMentorCandidates(this.tablecandidates).subscribe(
        response=>{
          console.log(response);
        },
       error =>{
        console.error(error);
       }
       );
  }
}
