import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import {AuthService} from '../../core/services/auth.service';
import {NotificationService} from '../../core/services/notificationService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  returnUrl: string;
  loginForm = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });
  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private notificationService: NotificationService
  ) { }

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

  onSubmit(): void {
    this.authService.login(this.loginForm.value).subscribe(res => {
      if (this.authService.getRole() === 'User') {
        this.router.navigateByUrl('/home');
      }
      if (this.authService.getRole() === 'Agent') {
        this.router.navigateByUrl('/agent/home');
      }
    }, err => {
      console.log(err);
      this.notificationService.warn('Incorrect password or email');
    });
  }
}
