import { JwtHelperService } from '@auth0/angular-jwt';
import {accountUrl} from '../../configs/api-endpoint.constants';
import {JwtService} from './jwt.service';
import { Router } from '@angular/router';
import {JwtResponseModel} from '../models/jwt-response.model';
import {Injectable} from '@angular/core';
import {Observable, of} from 'rxjs';
import {map} from 'rxjs/operators';
import {FileInput} from 'ngx-material-file-input';
import {ApiService} from './api.service';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  constructor(
    private jwtHelper: JwtHelperService,
    private http: ApiService,
    private jwtService: JwtService,
    private router: Router
  ) {}
  agentRegister = new FormData();
  isLoggedIn = false;
  readonly baseUrl = accountUrl;

  logout(): void{
    this.jwtService.removeToken();
    this.isLoggedIn = false;
    this.router.navigateByUrl('/login');
  }

  isAuthenticated(): boolean {
    return this.jwtService.checkToken();
  }

  login(loginData): Observable<boolean> {
    return this.http.post(`${this.baseUrl}/login`, loginData).pipe(map((response: JwtResponseModel) => {
      this.jwtService.addTokenToLS(response.token);
      if (!this.jwtService.checkToken()) {
        return false;
      }
      this.isLoggedIn = true;
      return true;
    }));
  }
  registerUser(registerForm): Observable<boolean>  {
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
    return this.http.post(`${this.baseUrl}`, formData).pipe(map((response: JwtResponseModel) => {
      this.jwtService.addTokenToLS(response.token);
      if (!this.jwtService.checkToken()) {
        return false;
      }
      this.isLoggedIn = true;
      return true;
    }));
  }

  firstStep(registerForm): void{
    this.agentRegister.append('Email', registerForm.Email);
    this.agentRegister.append('FirstName', registerForm.FirstName);
    this.agentRegister.append('LastName', registerForm.LastName);
    this.agentRegister.append('Password', registerForm.Password);
    this.agentRegister.append('ConfirmPassword', registerForm.ConfirmPassword);
    this.agentRegister.append('PhoneNumber', registerForm.PhoneNumber);
  }
  secondStep(agentRegisterForm): void{
    if (agentRegisterForm.BirthDate !== '') {
      const date = new Date(agentRegisterForm.BirthDate);
      this.agentRegister.append('AgentProfile[BirthDate]', date.toDateString());
    }
    this.agentRegister.append('AgentProfile[City]', agentRegisterForm.City);
    this.agentRegister.append('AgentProfile[Description]', agentRegisterForm.Description);
    this.agentRegister.append('AgentProfile[DefaultRate]', agentRegisterForm.DefaultRate);
  }
  registerAgent(registerForm): Observable<boolean> {
    const Img: FileInput = registerForm.Image;
    const file = Img.files[0];
    this.agentRegister.append('Image', file);
    return this.http.post(`${this.baseUrl}/agent`, this.agentRegister).pipe(map((response: JwtResponseModel)  => {
      this.jwtService.addTokenToLS(response.token);
      if (!this.jwtService.checkToken()) { return false; }
      this.isLoggedIn = true;
      return true;
    }));
  }

  getRole(): string{
   const role = this.jwtService.getRole();
   return role;
  }
}
