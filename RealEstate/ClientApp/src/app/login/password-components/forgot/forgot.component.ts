import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {UserService} from '../../../core/services/user.servicce';
import {NotificationService} from '../../../core/services/notificationService';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.scss']
})
export class ForgotComponent implements OnInit {

  constructor(private userService: UserService, private notificationService: NotificationService) { }
  forgotForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
  });
  ngOnInit(): void {
  }
  sendEmail(): any {
    return this.userService.forgotPassword(this.forgotForm.value.email).subscribe(() => {
      this.notificationService.success('Check your email to confirm your account.');
    }, err => {
      this.notificationService.warn('Some data must be incorrect. Please, check.');
    });
  }
}
