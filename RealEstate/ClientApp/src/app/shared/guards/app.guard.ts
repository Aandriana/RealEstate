import { Injectable } from '@angular/core';
import {CanActivate, Router} from '@angular/router';
import {AuthService} from '../../core/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AppGuard implements CanActivate {
  constructor(public auth: AuthService, public router: Router) {}
  canActivate(): boolean {
    if (this.auth.isAuthenticated()) {
      if (this.auth.getRole() === 'Agent'){
        this.router.navigateByUrl('agent/home');
        return true;
        }
      if (this.auth.getRole() === 'User'){
        this.router.navigateByUrl('home');
        return true;
      }
    }
    this.router.navigateByUrl('login');
    return true;
  }
}
