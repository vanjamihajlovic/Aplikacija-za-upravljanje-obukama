import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Training } from '../../shared/model/training';
import { MatDialog } from '@angular/material/dialog';
import { AddCourseDialogComponent } from '../add-course-dialog/add-course-dialog.component';
import { Course } from '../../shared/model/course';
import { TrainingService } from '../../shared/services/training.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-training',
  templateUrl: './add-training.component.html',
  styleUrl: './add-training.component.css'
})
export class AddTrainingComponent implements OnInit {

  // public dataSource = new MatTableDataSource<any>();
  // public displayedColumns = ['name','description','startDate','mentor','duration','nModules'];
  dataSource = new MatTableDataSource<Course>();
  displayedColumns: string[] = ['name', 'startDate', 'mentor', 'duration', 'numOfModules'];
  public training: Training = new Training();

  constructor(private dialog: MatDialog, private trainingService: TrainingService, private router: Router) { }

  ngOnInit(): void {
   
  }

  addCourseDialog() : void {
    this.dialog.open(AddCourseDialogComponent, { 
    width: '500px', 
    data: {}
    }).afterClosed().subscribe((newCourse: Course) => {
      newCourse.startDateString = newCourse.startDate.toJSON();
      console.log(newCourse.startDate);
      const data = this.dataSource.data;
      data.push(newCourse);
      this.dataSource.data = data;
      
    }); 
}

addTraining() : void {
  this.training.courses = this.dataSource.data;
  console.log(this.training);
  this.trainingService.addNewTraining(this.training).subscribe(res=> {
    this.router.navigate(['/home-admin']);
  });
}

}