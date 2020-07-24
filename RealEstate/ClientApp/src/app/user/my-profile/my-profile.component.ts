import { Component, OnInit } from '@angular/core';
import {UserService} from '../../core/services/user.servicce';
import {UserProfile} from '../../core/models';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit {
   userProfile = UserProfile;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getMyProfile();
  }
  getMyProfile(): any{
   return this.userService.getMyProfile()
     .subscribe(data => this.userProfile = data);
  }
}
