import { Component } from '@angular/core';
import { Course } from '../shared/model/course';
import { Mentor } from '../shared/model/mentor';
import { Candidate } from '../shared/model/candidate';
import { User } from '../shared/model/User';


@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrl: './candidate.component.css'
})
export class CandidateComponent {
  
  candidate1: User =new User();
  candidate2: User =new User();
  candidates: User[] =  [this.candidate1, this.candidate2];

  courses : Course[] = [
    {
      name:  "111",
      description: "fgdfbgdfbdfb",
      startDate: new Date(12,12,1212),
      numOfModules: 2,
      duration: 2,
      candidates: this.candidates,
      mentor: new User(),
      mentorId: ""
    },
    {
      name:  "222",
      description: "ggggggggg",
      startDate: new Date(12,12,1212),
      numOfModules: 2,
      duration: 2,
      candidates: this.candidates,
      mentor: new User(),
      mentorId: ""
    }
    ];


}
