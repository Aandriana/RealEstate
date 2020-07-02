import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import {MatCardModule} from '@angular/material/card';
import {ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {LoginRoutingModule} from './login-routing.module';
import {MatInputModule} from '@angular/material/input';
import { RegistrationComponent } from './registration/registration.component';
import { AgentRegistrationComponent } from './agent-registration/agent-registration.component';



@NgModule({
  declarations: [LoginComponent, RegistrationComponent, AgentRegistrationComponent],
  imports: [
    CommonModule,
    MatCardModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    LoginRoutingModule,
    MatInputModule,
  ]
})
export class LoginModule { }
