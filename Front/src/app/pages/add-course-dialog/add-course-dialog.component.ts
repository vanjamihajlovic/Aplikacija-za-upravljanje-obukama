import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Course } from '../../shared/model/course';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IDropdownSettings,  } from 'ng-multiselect-dropdown';
import { User } from '../../shared/model/User';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-add-course-dialog',
  templateUrl: './add-course-dialog.component.html',
  styleUrl: './add-course-dialog.component.css'
})
export class AddCourseDialogComponent {

  form: FormGroup;
  candidates: User[] = [];
  selectedCandidates: User[] = [];
  mentors: User[] = [];
  selectedMentor: User = new User();
  dropdownSettings : IDropdownSettings= {};
  

  constructor( 
    public dialogRef: MatDialogRef<AddCourseDialogComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: Course, private fb: FormBuilder, private userService: UserService) {
      this.form = this.fb.group({
        name: [this.data.name, Validators.required],
        description: [this.data.description],
        startDate: [this.data.startDate],
        numOfModules: [this.data.numOfModules],
        duration: [this.data.duration]
      });
      
      this.dropdownSettings = {
        singleSelection: false,
        idField: 'id',
        textField: 'firstName',
        selectAllText: 'Select All',
        unSelectAllText: 'UnSelect All',
        itemsShowLimit: 3,
        allowSearchFilter: true
      };
      userService.getAllCandidates().subscribe(res=> {
        console.log(res)
        this.candidates = res;
      });
      userService.getAllMentors().subscribe(res=> {
        this.mentors = res;
      });
  }
     
  onCancel(): void { 
    this.dialogRef.close(); 
  }  

  onItemSelect(item: any) {
    console.log(item);
    this.selectedCandidates.push(item);
    this.form.value.candidates = this.selectedCandidates;
  }
  onSelectAll(items: any) {
  }

  onDeSelect(item: any) 
  {
    this.selectedCandidates = this.selectedCandidates.filter(prj => prj.id !== item.id);
    this.form.value.candidates = this.selectedCandidates;
  }

  selectMentor(mentor: User) {
    this.form.value.mentor = this.selectedMentor;
    this.form.value.mentorId = this.selectedMentor.id;
  }
}
