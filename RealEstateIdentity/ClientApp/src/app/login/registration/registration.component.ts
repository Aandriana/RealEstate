import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../core/services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  hide = true;
  imageSrc: string | ArrayBuffer;
  returnUrl: string;

  constructor( private fb: FormBuilder, private authService: AuthService, private router: Router, private route: ActivatedRoute) { }

  registrationForm = new FormGroup({
    Email: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.email]),
    Password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    ConfirmPassword: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    FirstName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    LastName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    PhoneNumber: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(15), Validators.pattern(/^\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})$/g)]),
    Image: new FormControl(null,[Validators.required, Validators.max(1)])
  });
  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  onSubmit(): void {
    this.authService.registerUser(this.registrationForm.value);
    this.router.navigateByUrl('');
  }
}
