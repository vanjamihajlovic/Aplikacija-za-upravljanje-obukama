import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TablestudentsComponent } from '../tablestudents/tablestudents.component';

@Component({
  selector: 'app-mentor',
  templateUrl: './mentor.component.html',
  styleUrl: './mentor.component.css'
})
export class MentorComponent implements OnInit {

  kursevi = [
    {name: 'Python', description: 'Osnovni koncepti Pythona',duration: '120', module: '5'},
    {name: 'C#', description: 'Osnovni koncepti C#',duration: '120', module: '5'},
    {name: 'Angular', description: 'Osnovni koncepti u Angularu',duration: '120', module: '5'},
    {name: 'React', description: 'Osnovni koncepti u Reactu',duration: '120', module: '5'}
  ];

  constructor(public dialog: MatDialog) {}
  ngOnInit(): void {
  
  }
  

  openModal(kurs: any): void {
    const dialogRef = this.dialog.open(TablestudentsComponent, {
      width: '800px',
      height: '400px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
}

}
