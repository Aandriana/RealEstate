import { JwtHelperService } from '@auth0/angular-jwt';
import {Injectable} from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class JwtService {
  constructor(
    private jwtHelper: JwtHelperService
  ) {}

  public addTokenToLS(token): void
  {
    localStorage.setItem('jwt', token);
  }
  public removeToken(): void
  {
    localStorage.removeItem('jwt');
  }
   public checkToken(): boolean {
     const token: string = localStorage.getItem('jwt');
     return !this.jwtHelper.isTokenExpired(token);
   }
    public getRole(): string
    {
      const token: string = localStorage.getItem('jwt');
      if (!this.jwtHelper.isTokenExpired(token)) {
        const role = this.jwtHelper.decodeToken(token)[
          'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
          ];
        return role;
      }
      return null;
    }
}

