import { Component, OnInit } from '@angular/core';
import {MenuItem} from '../../../core/models';
import {Router} from '@angular/router';
import {JwtService} from '../../../core/services/jwt.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {
  menuItems: MenuItem[] = [
    {
      label: 'Home',
      showOnMobile: false,
      showOnTablet: true,
      showOnDesktop: true,
      click: '/home'
    },
    {
      label: 'Properties',
      showOnMobile: false,
      showOnTablet: true,
      showOnDesktop: true,
      click: '/properties'
    },
    {
      label: 'Account',
      showOnMobile: false,
      showOnTablet: false,
      showOnDesktop: true,
      click: '/profile'
    },
    {
      label: 'Logout',
      showOnMobile: false,
      showOnTablet: false,
      showOnDesktop: true,
      click: '/login'
    },
  ];

  constructor(private router: Router, private jwtService: JwtService) {
  }

  ngOnInit(): void {
  }

  onClick(route): any {
    if (route === '/login') {
      this.jwtService.removeToken();
    }
    this.router.navigateByUrl(`${route}`);
  }
}

