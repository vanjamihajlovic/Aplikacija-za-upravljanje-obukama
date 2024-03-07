import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Course } from '../../shared/model/course';
import { Training } from '../../shared/model/training';
import { TrainingService } from '../../shared/services/training.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-training',
  templateUrl: './view-training.component.html',
  styleUrl: './view-training.component.css'
})
export class ViewTrainingComponent implements OnInit {

  // public dataSource = new MatTableDataSource<any>();
  // public displayedColumns = ['name','description','startDate','mentor','duration','nModules'];
  dataSource = new MatTableDataSource<Course>();
  displayedColumns: string[] = ['name', 'startDate', 'mentor', 'duration', 'numOfModules'];
  public training: Training = new Training();

  constructor(private trainingService: TrainingService, private router: Router) { }

  ngOnInit(): void {
    this.trainingService.getTrainingById('0F8154BC-0F78-46B4-8446-08DC3DE92AD2').subscribe(res=> {
      this.training = res;
    })
  }

}