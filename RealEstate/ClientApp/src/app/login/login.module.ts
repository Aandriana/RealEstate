import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatCardModule} from '@angular/material/card';
import {ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatGridListModule} from '@angular/material/grid-list';
import {FlexModule} from '@angular/flex-layout';
import {MaterialFileInputModule} from 'ngx-material-file-input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatStepperModule} from '@angular/material/stepper';
import {LoginRoutingModule} from './login-routing.module';
import * as __ from './';
import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations: [
    __.LoginComponent,
    __.RegistrationComponent,
    __.AgentRegistrationComponent,
    __.ChooseRegistrationComponent,
    __.ConfirmationComponent,
    __.ForgotComponent,
    __.ResetComponent],
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
    MatStepperModule,
    MatButtonModule
  ],
  exports: [
    MatDatepickerModule
  ]
})
export class LoginModule { }
