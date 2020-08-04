import { Injectable } from '@angular/core';
import {CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router} from '@angular/router';
import { Observable } from 'rxjs';
import {AuthService} from '../core/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {
  constructor(public auth: AuthService, public router: Router) {}
  canActivate(): boolean{
    if (this.auth.isAuthenticated()) {
      if (this.auth.getRole() === 'User') {
        this.router.navigateByUrl('/home');
        return false;
      }
      if (this.auth.getRole() === 'Agent') {
        this.router.navigateByUrl('/agent/home');
        return false;
      }
    }
    return true;
  }
}
