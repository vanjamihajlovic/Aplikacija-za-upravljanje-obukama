import { Component } from '@angular/core';

@Component({
  selector: 'app-tablestudents',
  templateUrl: './tablestudents.component.html',
  styleUrl: './tablestudents.component.css'
})
export class TablestudentsComponent {
  items: any[] = [
    { name: 'Candidate 1', feedback: 'Dobar', ocena: 5, zavrsetakKursa: '01.01.2024' },
    { name: 'Candidate 2', feedback: 'Odličan', ocena: 4.5, zavrsetakKursa: '15.02.2024' },
    { name: 'Candidate 3', feedback: 'Prosečan', ocena: 3, zavrsetakKursa: '30.03.2024' }
  ];
  isDropdownOpen: boolean[] = [];
  constructor() {
    this.isDropdownOpen = [];
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
}
