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
    private router: Router,
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
    const Img: FileInput = registerForm.image;
    const file = Img.files[0];
    for(const user in registerForm) {
      formData.append(user, registerForm[user]);
    }
    formData.append('image', file);
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
    for(const user in registerForm) {
      this.agentRegister.append(user, registerForm[user]);
    }
  }
  secondStep(agentRegisterForm): void {
    for (const user in agentRegisterForm) {
      this.agentRegister.append(`agentProfile[${user}]`, agentRegisterForm[user]);
    }
    if (agentRegisterForm.birthDate !== '') {
      const date = new Date(agentRegisterForm.birthDate);
      this.agentRegister.set('agentProfile[birthDate]', date.toDateString());
    }
  }
  registerAgent(registerForm): Observable<boolean> {
    const Img: FileInput = registerForm.image;
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
