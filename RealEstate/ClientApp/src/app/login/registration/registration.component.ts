import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../core/services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import {NotificationService} from '../../core/services/notificationService';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  hide = true;
  returnUrl: string;

  constructor( private fb: FormBuilder, private authService: AuthService, private router: Router, private route: ActivatedRoute, private notificationService: NotificationService) { }

  registrationForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    confirmPassword: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    firstName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    phoneNumber: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(15), Validators.pattern(/^\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})$/g)]),
    image: new FormControl(null, [Validators.required, Validators.max(1)])
  });
  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  onSubmit(): void {
    this.authService.registerUser(this.registrationForm.value).subscribe(res => {
      this.router.navigateByUrl('/home');
    }, err => {
        console.log(err);
        this.notificationService.warn('Some data must be incorrect. Please, check.');
      });
  }
}
