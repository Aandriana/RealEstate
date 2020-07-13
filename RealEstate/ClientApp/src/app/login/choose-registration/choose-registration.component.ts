import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-choose-registration',
  templateUrl: './choose-registration.component.html',
  styleUrls: ['./choose-registration.component.scss']
})
export class ChooseRegistrationComponent implements OnInit {
  private breakpoint: number;

  constructor(
    private router: Router,
  ) { }

  ngOnInit() {
  }

  registerAsAgent(): void {
    this.router.navigateByUrl('/registration/agent');
  }

  registerAUser(): void {
    this.router.navigateByUrl('/registration/user');
  }
}
