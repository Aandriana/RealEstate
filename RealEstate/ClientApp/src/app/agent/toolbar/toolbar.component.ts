import { Component, OnInit } from '@angular/core';
import {MenuItem} from '../../core/models';
import {Router} from '@angular/router';

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
      label: 'About',
      showOnMobile: false,
      showOnTablet: true,
      showOnDesktop: true,
      click: '/home'
    },
    {
      label: 'Properties',
      showOnMobile: false,
      showOnTablet: false,
      showOnDesktop: true,
      click: '/home'
    },
    {
      label: 'Requests',
      showOnMobile: false,
      showOnTablet: false,
      showOnDesktop: true,
      click: '/home'
    },
    {
      label: 'Account',
      showOnMobile: false,
      showOnTablet: false,
      showOnDesktop: true,
      click: '/profile'
    },
  ];
  constructor( private router: Router) { }

  ngOnInit(): void {
  }

  onClick(route): any{
    this.router.navigateByUrl(`${'agent/home'}`);
  }
}

