import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {RegistrationComponent} from './registration/registration.component';
import {AgentRegistrationComponent} from './agent-registration/agent-registration.component';
import {ChooseRegistrationComponent} from './choose-registration/choose-registration.component';
import {ConfirmationComponent} from './confirmation/confirmation.component';
import {LoginGuard} from '../shared/guards';

const routes: Routes = [
  { path: 'login', component: LoginComponent, canActivate: [LoginGuard]},
  {path: 'registration/confirm', component: ConfirmationComponent, canActivate: [LoginGuard]},
  { path: 'registration/user', component: RegistrationComponent, canActivate: [LoginGuard]},
  { path: 'registration/agent', component: AgentRegistrationComponent, canActivate: [LoginGuard]},
  { path: 'registration', component: ChooseRegistrationComponent, canActivate: [LoginGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class LoginRoutingModule {}
