import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {UserService} from '../../../core/services/user.servicce';
import {UserProfile} from '../../../core/models';
import {Router} from '@angular/router';

@Component({
  selector: 'app-my-profile-edit',
  templateUrl: './my-profile-edit.component.html',
  styleUrls: ['./my-profile-edit.component.scss']
})
export class MyProfileEditComponent implements OnInit {
  constructor(private userService: UserService, private router: Router) {
  }
  imageSrc: string | ArrayBuffer;
  user: UserProfile;
  editProfileForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(50), Validators.email]),
    firstName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    phoneNumber: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(15), Validators.pattern(/^\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})$/g)]),
    image: new FormControl(null, [Validators.max(1)])
  });

  ngOnInit(): void {
    this.userService.getMyProfile().subscribe(value => {
      this.user = value as UserProfile;
      this.editProfileForm.setValue({
        firstName: this.user.firstName,
        lastName: this.user.lastName,
        image: null,
        phoneNumber: this.user.phoneNumber,
        email: this.user.email
      });
    });
  }

  editProfile(): void {
    this.userService.editMyProfile(this.editProfileForm.value).subscribe(() =>
      this.router.navigateByUrl('/profile'));
  }

  onFileChange(event): any {
    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      const reader = new FileReader();
      reader.onload = e => this.imageSrc = reader.result;

      reader.readAsDataURL(file);

      this.editProfileForm.patchValue({
        image: file,
      });
    }
  }
  getPhoto(): string {
    return 'http://localhost:52833/' + this.user.imagePath;
  }
  avatarChange(): any {
    document.getElementById('input-file-id').click();
  }
}
