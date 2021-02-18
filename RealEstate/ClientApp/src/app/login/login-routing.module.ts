import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginGuard} from '../shared/guards';
import * as __ from './';

const routes: Routes = [
  { path: 'login', component: __.LoginComponent, canActivate: [LoginGuard]},
  { path: 'registration/confirm', component: __.ConfirmationComponent, canActivate: [LoginGuard]},
  { path: 'registration/user', component: __.RegistrationComponent, canActivate: [LoginGuard]},
  { path: 'registration/agent', component: __.AgentRegistrationComponent, canActivate: [LoginGuard]},
  { path: 'registration', component: __.ChooseRegistrationComponent, canActivate: [LoginGuard]},
  { path: 'password/forgot', component: __.ForgotComponent, canActivate: [LoginGuard]},
  { path: 'password/reset', component: __.ResetComponent, canActivate: [LoginGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class LoginRoutingModule {}
