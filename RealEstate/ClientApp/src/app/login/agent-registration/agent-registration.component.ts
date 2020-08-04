import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import {AuthService} from '../../core/services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import {NotificationService} from '../../core/services/notificationService';
@Component({
  selector: 'app-agent-registration',
  templateUrl: './agent-registration.component.html',
  styleUrls: ['./agent-registration.component.scss']
})
export class AgentRegistrationComponent implements OnInit {
  hide = true;
  isLinear = false;
  returnUrl: string;
  agentProfile = new FormGroup({
    birthDate: new FormControl(''),
  city: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]),
  description: new FormControl('', Validators.maxLength(400)),
    defaultRate: new FormControl('', [Validators.required, Validators.pattern(/^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$/)])
});
  registrationForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    confirmPassword: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    firstName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    phoneNumber: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(15), Validators.pattern(/^\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})$/g)]),
});
  imageForm = new FormGroup({
    image: new FormControl(null, [Validators.required, Validators.max(1)])
  })
  maxDate: Date;
  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private route: ActivatedRoute, private notificationService: NotificationService) {}
  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }
  onFirstSubmit(): void{
    this.authService.firstStep(this.registrationForm.value);
  }
  onSecondSubmit(): void{
    this.authService.secondStep(this.agentProfile.value);
  }
  onSubmit(): void {
    this.authService.registerAgent(this.imageForm.value).subscribe(res => {
      this.router.navigateByUrl('/agent/home');
    }, err => {
      console.log(err);
      this.notificationService.warn('Some data must be incorrect. Please, check.');
    });
  }
}
