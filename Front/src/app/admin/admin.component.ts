import { Component, OnInit } from '@angular/core';
import { TrainingService } from '../shared/services/training.service';
import { Training } from '../shared/model/training';
import { Router } from '@angular/router';
import { TrainingView } from '../shared/model/training-view';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit{

  imageUrl :string = 'assets/c.png';

  trainings: TrainingView[] = []

  constructor(private trainingService: TrainingService, private router: Router) {}

  ngOnInit(): void {
    this.trainingService.getAllTrainings().subscribe(res=> {
      this.trainings = res;
    })
  }

  addNewTraining() {
    this.router.navigate(['/add-training']);
  }

  showTraining(id: string) {
    this.router.navigate(['/view-training', id]);
  }
}
