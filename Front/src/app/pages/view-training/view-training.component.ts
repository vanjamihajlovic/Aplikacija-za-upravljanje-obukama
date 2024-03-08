import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Course } from '../../shared/model/course';
import { Training } from '../../shared/model/training';
import { TrainingService } from '../../shared/services/training.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../shared/services/course.service';

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
  id: string = "";
  constructor(private trainingService: TrainingService, private route: ActivatedRoute, private courseService: CourseService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id  = params['id'];
    })
    this.trainingService.getTrainingById(this.id).subscribe(res=> {
      this.training = res;
    })

    this.courseService.getAllCoursesByTrainingId(this.id).subscribe(res=> {
      this.dataSource.data = res;
    })
  }

}