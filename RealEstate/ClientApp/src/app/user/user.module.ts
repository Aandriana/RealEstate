import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {UserRoutingModule} from './user-routing.module';
import { HomeComponent } from './home/home.component';
import {AuthGuard} from '../shared/auth-guard.service';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
  ],
  providers: [
      AuthGuard
  ]
})

export class UserModule { }
