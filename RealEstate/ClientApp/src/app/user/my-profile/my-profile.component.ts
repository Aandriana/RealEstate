import { Component, OnInit } from '@angular/core';
import {UserService} from '../../core/services/user.servicce';
import {UserProfile} from '../../core/models';
import {Router} from '@angular/router';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit {
   userProfile: UserProfile;
   button = 'Edit profile';
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.getMyProfile();
  }
  getMyProfile(): any{
    this.userService.getMyProfile()
     .subscribe(data => this.userProfile = data);
  }
  editProfile(): any{
    this.router.navigateByUrl('profile/edit');
  }
}
