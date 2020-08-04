import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../core/services/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-not-found-page',
  templateUrl: './not-found-page.component.html',
  styleUrls: ['./not-found-page.component.scss']
})
export class NotFoundPageComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }
  redirection(): any {
    if (this.authService.getRole() === 'User') {
      this.router.navigateByUrl('/home');
    }
    if (this.authService.getRole() === 'Agent') {
      this.router.navigateByUrl('/agent/home');
    }
  }
}
