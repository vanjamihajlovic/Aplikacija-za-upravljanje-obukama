import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Course } from '../../shared/model/Course';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { IDropdownSettings,  } from 'ng-multiselect-dropdown';
import { User } from '../../shared/model/User';

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
  selectedMentor: any;
  dropdownSettings : IDropdownSettings= {};
  

  constructor( 
    public dialogRef: MatDialogRef<AddCourseDialogComponent>, 
    @Inject(MAT_DIALOG_DATA) public data: Course, private fb: FormBuilder) {
      this.form = this.fb.group({
        name: [this.data.name, Validators.required],
        description: [this.data.description],
        startDate: [this.data.startDate],
        nModules: [this.data.nModules],
        duration: [this.data.duration]
      });
      this.candidates = [
        { id: "a13dasd", email: "mail@mail.com", firstName: "Milan", lastName: "Milanovic", role: "CANDIDATE"},
        { id: "a3dasdasd", email: "mail@mail.com", firstName: "Marko", lastName: "Markovic", role: "CANDIDATE"}
      ]
      this.mentors = [
        { id: "adaasdsd", email: "mail@mail.com", firstName: "Saban", lastName: "Saulic", role: "MENTOR"},
        { id: "adaad2sd", email: "mail@mail.com", firstName: "Radoje", lastName: "Mandic", role: "MENTOR"}
      ]
      this.dropdownSettings = {
        singleSelection: false,
        idField: 'id',
        textField: 'firstName',
        selectAllText: 'Select All',
        unSelectAllText: 'UnSelect All',
        itemsShowLimit: 3,
        allowSearchFilter: true
      };
  }
     
  onCancel(): void { 
    this.dialogRef.close(); 
  }  

  onItemSelect(item: any) {
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
  }
}
