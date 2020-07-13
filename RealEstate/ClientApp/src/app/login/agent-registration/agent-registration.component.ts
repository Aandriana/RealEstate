import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import {AuthService} from '../../core/services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-agent-registration',
  templateUrl: './agent-registration.component.html',
  styleUrls: ['./agent-registration.component.scss']
})
export class AgentRegistrationComponent implements OnInit {
  hide = true;
  isEditable = false;
  imageSrc: string | ArrayBuffer;
  isLinear = false;
  returnUrl: string;
  AgentProfile = new FormGroup({
    BirthDate: new FormControl(''),
  City: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]),
  Description: new FormControl('', Validators.maxLength(400)),
    DefaultRate: new FormControl('', [Validators.required, Validators.pattern(/^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$/)])
})

  registrationForm = new FormGroup({
    Email: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.email]),
    Password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    ConfirmPassword: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]),
    FirstName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    LastName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    PhoneNumber: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(15), Validators.pattern(/^\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})$/g)]),
    Image: new FormControl(null,[Validators.required, Validators.max(1)])
});
  maxDate: Date;
  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private route: ActivatedRoute) {}
  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }
  onFirstSubmit(): void{
    this.authService.firstStep(this.registrationForm.value);
  }
  onSecondSubmit(): void{
    this.authService.secondStep(this.AgentProfile.value);
  }
  onSubmit(): void {
    this.authService.registerAgent(this.registrationForm.value).subscribe(res => {
      if (!res) console.error('error');
      this.router.navigateByUrl('/home');
    });
  }
}
