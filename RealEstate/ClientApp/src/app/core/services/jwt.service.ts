import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import {Injectable} from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class JwtService {
  constructor(
    private jwtHelper: JwtHelperService, private http: HttpClient,
  ) {}

  public addTokenToLS(token): void
  {
    localStorage.setItem('jwt', token);
  }
  public removeToken(): void
  {
    localStorage.removeItem('jwt');
  }
   public checkToken(): boolean
   {
  const token: string = localStorage.getItem('jwt');
  return token && !this.jwtHelper.isTokenExpired(token);
    }

}

