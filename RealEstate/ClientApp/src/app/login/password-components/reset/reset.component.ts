import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {UserService} from '../../../core/services/user.servicce';
import {NotificationService} from '../../../core/services/notificationService';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-reset',
  templateUrl: './reset.component.html',
  styleUrls: ['./reset.component.scss']
})
export class ResetComponent implements OnInit {

  constructor(private userService: UserService, private route: ActivatedRoute, private notificationService: NotificationService, private router: Router) { }
  hide = true;
  resetForm = new FormGroup({
    password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    confirmPassword: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    code: new FormControl(''),
    id: new FormControl('')
  });
  ngOnInit(): void {
    this.route.queryParams.subscribe(value => {
      this.resetForm.patchValue({
        code: value.code,
        id: value.id
      });
    });
  }
  changePassword(): any{
    this.userService.resetPassword(this.resetForm.value).subscribe(() => {
      this.router.navigateByUrl('login');
      this.notificationService.success('Password was reset');
    }, err => {
      this.notificationService.warn('Something went wrong :(');
    });
  }
}
