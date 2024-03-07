import { Component, OnInit } from '@angular/core';
import { TrainingService } from '../shared/services/training.service';
import { Training } from '../shared/model/training';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit{

  imageUrl :string = 'assets/slika.webp';

  trainings: Training[] = []

  constructor(private trainingService: TrainingService, private router: Router) {}

  ngOnInit(): void {
    this.trainingService.getAllTrainings().subscribe(res=> {
      this.trainings = res;
    })
  }

  addNewTraining() {
    this.router.navigate(['/add-training']);
  }
}
