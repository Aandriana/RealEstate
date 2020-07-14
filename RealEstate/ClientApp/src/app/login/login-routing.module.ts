import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {RegistrationComponent} from './registration/registration.component';
import {AgentRegistrationComponent} from './agent-registration/agent-registration.component';
import {ChooseRegistrationComponent} from './choose-registration/choose-registration.component';
import {AuthGuard} from '../shared/auth-guard.service';

const routes: Routes = [
  { path: 'login', component: LoginComponent , canActivate: [!AuthGuard]},
  { path: 'registration', component: ChooseRegistrationComponent, canActivate: [!AuthGuard]},
  { path: 'registration/user', component: RegistrationComponent, canActivate: [!AuthGuard]},
  { path: 'registration/agent', component: AgentRegistrationComponent, canActivate: [!AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class LoginRoutingModule {}
