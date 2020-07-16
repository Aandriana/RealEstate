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
import {AuthService} from '../core/services/auth.service';
import {JwtService} from '../core/services/jwt.service';
import {MatIconModule} from '@angular/material/icon';
import {ChooseRegistrationComponent} from './choose-registration/choose-registration.component';
import {MatGridListModule} from '@angular/material/grid-list';
import {FlexModule} from '@angular/flex-layout';
import {MaterialFileInputModule} from 'ngx-material-file-input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatStepperModule} from '@angular/material/stepper';
import {ApiService} from '../core/services/api.service';



@NgModule({
  declarations: [LoginComponent, RegistrationComponent, AgentRegistrationComponent, ChooseRegistrationComponent],
    imports: [
        CommonModule,
        MatCardModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        LoginRoutingModule,
        MatInputModule,
        MatIconModule,
        MatGridListModule,
        FlexModule,
        MaterialFileInputModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatStepperModule
    ],
  exports: [
    MatDatepickerModule
  ]
})
export class LoginModule { }
