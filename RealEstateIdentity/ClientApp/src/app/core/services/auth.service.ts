import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import {accountUrl} from '../../configs/api-endpoint.constants';
import {JwtService} from './jwt.service';
import { Router } from '@angular/router';
import {JwtResponseModel} from '../models/jwt-response.model';
import {Injectable} from '@angular/core';
import {Observable, of} from 'rxjs';
import {delay, tap} from 'rxjs/operators';
import {FileInput} from 'ngx-material-file-input';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(
    private jwtHelper: JwtHelperService, private http: HttpClient, private jwtService: JwtService, private router: Router
  ) {}
  isLoggedIn = false;
  redirectUrl: string;
  readonly baseUrl = accountUrl;

  logout(): void{
    this.jwtService.RemoveToken();
    this.isLoggedIn = false;
    this.router.navigateByUrl('/login');
  }

  isAuthenticated(): boolean {
    return this.jwtService.CheckToken();
  }

  login(loginData): Observable<boolean> {
    this.http.post(`${this.baseUrl}/login`, loginData).subscribe((response: JwtResponseModel) => {
      this.jwtService.AddTokenToLS(response.token.result);
      console.log(response.token);
    }, error => {
      console.log(error);
    });
    return of(true).pipe(
      delay(1000),
      tap(val => this.isLoggedIn = true)
    );
  }

  registerUser(registerForm): void {
    const formData = new FormData();
    const Img: FileInput = registerForm.Image;
    const file = Img.files[0];
    formData.append('Email', registerForm.Email);
    formData.append('FirstName', registerForm.FirstName);
    formData.append('LastName', registerForm.LastName);
    formData.append('Password', registerForm.Password);
    formData.append('ConfirmPassword', registerForm.ConfirmPassword);
    formData.append('PhoneNumber', registerForm.PhoneNumber);
    formData.append('Image', file);
    this.http.post(`${this.baseUrl}`, formData).subscribe((response: JwtResponseModel) => {
      this.jwtService.AddTokenToLS(response.token.result);
      console.log(response.token);
    }, error => {
      console.log(error);
    });
  }
  registerAgent(registerForm, agentRegisterForm): void {
    const formData = new FormData();
    const Img: FileInput = registerForm.Image;
    const file = Img.files[0];
    formData.append('FirstName', registerForm.FirstName);
    formData.append('LastName', registerForm.LastName);
    formData.append('Email', registerForm.Email);
    formData.append('Password', registerForm.Password);
    formData.append('ConfirmPassword', registerForm.ConfirmPassword);
    formData.append('PhoneNumber', registerForm.PhoneNumber);
    formData.append('Image', file);
    formData.append('AgentProfile[BirthDate]', agentRegisterForm.Age);
    formData.append('AgentProfile[City]', agentRegisterForm.City);
    formData.append('AgentProfile[Description]', agentRegisterForm.Description);
    formData.append('Description[DefaultRate]', agentRegisterForm.DefaultRate);
    this.http.post(`${this.baseUrl}/agent`, formData).subscribe((response: JwtResponseModel) => {
      this.jwtService.AddTokenToLS(response.token.result);
      console.log(response.token);
    }, error => {
      console.log(error);
    });

  }
}
