import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { AdminComponent } from './admin/admin.component';
import { AddTrainingComponent } from './pages/add-training/add-training.component';
import { MentorComponent } from './mentor/mentor.component';
import { CandidateComponent } from './candidate/candidate.component';
import { ViewTrainingComponent } from './pages/view-training/view-training.component';
import { AuthGuard } from './helpers/auth.guard';
import { RoleGuard } from './helpers/role.guard';

const routes: Routes = [
  {path: 'login', component: LoginPageComponent},
  {path: 'add-training', component: AddTrainingComponent, canActivate: [AuthGuard, RoleGuard], data: { roles: ['ADMINISTRATOR'] }},
  {path: 'home-admin', component: AdminComponent, canActivate: [AuthGuard, RoleGuard], data: { roles: ['ADMINISTRATOR'] }},
  {path: 'mentor', component: MentorComponent},
  {path: 'candidate', component: CandidateComponent},
  {path: 'view-training/:id', component: ViewTrainingComponent, canActivate: [AuthGuard, RoleGuard], data: { roles: ['ADMINISTRATOR'] }}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
