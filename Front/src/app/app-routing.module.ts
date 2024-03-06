import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { AdminComponent } from './admin/admin.component';
import { AddTrainingComponent } from './pages/add-training/add-training.component';
import { MentorComponent } from './mentor/mentor.component';
import { CandidateComponent } from './candidate/candidate.component';

const routes: Routes = [
  {path: 'login', component: LoginPageComponent},
  {path: 'add-training', component: AddTrainingComponent},
  {path: '', component: AdminComponent},
  {path: 'mentor', component: MentorComponent},
  {path: 'candidate', component: CandidateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
