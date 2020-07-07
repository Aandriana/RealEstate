import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from './login/login.component';
import {RegistrationComponent} from './registration/registration.component';
import {AgentRegistrationComponent} from './agent-registration/agent-registration.component';
import {ChooseRegistrationComponent} from './choose-registration/choose-registration.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: ChooseRegistrationComponent},
  { path: 'registration/user', component: RegistrationComponent},
  { path: 'registration/agent', component: AgentRegistrationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class LoginRoutingModule {}