import { Injectable } from '@angular/core';
import {CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router} from '@angular/router';
import { Observable } from 'rxjs';
import {AuthService} from '../../core/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserGuard implements CanActivate {
  constructor(public auth: AuthService, public router: Router) {}
canActivate(): boolean {
  if (!this.auth.isAuthenticated() || this.auth.getRole() !== 'User') {
    this.router.navigateByUrl('/');
    return false;
  }
  return true;
}
}
