import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {RegistrationComponent} from './registration/registration.component';
import {AgentRegistrationComponent} from './agent-registration/agent-registration.component';
import {ChooseRegistrationComponent} from './choose-registration/choose-registration.component';
import {LoginGuard} from '../shared/login.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent, canActivate: [LoginGuard]},
  { path: 'registration', component: ChooseRegistrationComponent, canActivate: [LoginGuard]},
  { path: 'registration/user', component: RegistrationComponent, canActivate: [LoginGuard]},
  { path: 'registration/agent', component: AgentRegistrationComponent, canActivate: [LoginGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class LoginRoutingModule {}
