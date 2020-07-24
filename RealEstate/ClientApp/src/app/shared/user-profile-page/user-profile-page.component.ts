import {Component, Input, OnInit} from '@angular/core';
import {UserProfile} from '../../core/models';

@Component({
  selector: 'app-user-profile-page',
  templateUrl: './user-profile-page.component.html',
  styleUrls: ['./user-profile-page.component.scss']
})
export class UserProfilePageComponent implements OnInit {
  @Input() user: UserProfile;
  constructor() { }

  ngOnInit(): void {
  }

}
