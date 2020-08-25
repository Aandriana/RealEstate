import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {AgentService} from '../../../core/services/agent.service';
import {AgentById} from '../../../core/models';
import {Router} from '@angular/router';

@Component({
  selector: 'app-my-profile-edit',
  templateUrl: './my-profile-edit.component.html',
  styleUrls: ['./my-profile-edit.component.scss']
})
export class MyProfileEditComponent implements OnInit {
  maxDate: Date;
  imageSrc: string | ArrayBuffer;
  agent: AgentById;
  agentProfile = new FormGroup({
    birthDate: new FormControl(''),
    city: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]),
    description: new FormControl('', Validators.maxLength(400)),
    defaultRate: new FormControl('', [Validators.required, Validators.pattern(/^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$/)])
  });
  userProfile = new FormGroup({
    firstName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]),
    image: new FormControl(null),
    email: new  FormControl(''),
    phoneNumber: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(15), Validators.pattern(/^\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})$/g)]),
  });
  constructor(private agentService: AgentService, private router: Router) { }

  ngOnInit(): void {
    this.agentService.getMyProfile().subscribe(value => {
      this.agent = value as AgentById;
      this.userProfile.setValue({
        email: this.agent.email,
        firstName: this.agent.firstName,
        lastName: this.agent.lastName,
        phoneNumber: this.agent.phoneNumber,
        image: null,
      });
      this.agentProfile.setValue({
        birthDate: this.agent.birthDate,
        city: this.agent.city,
        description: this.agent.description,
        defaultRate: this.agent.defaultRate,
      });
    });
  }

  editProfile(): void {
    this.agentService.editMyProfile(this.agentProfile.value, this.userProfile.value).subscribe(() =>
      this.router.navigateByUrl('agent/profile'));
  }

  onFileChange(event): any {
    if (event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      const reader = new FileReader();
      reader.onload = e => this.imageSrc = reader.result;

      reader.readAsDataURL(file);

      this.userProfile.patchValue({
        image: file,
      });
    }
  }

  avatarChange(): any {
    document.getElementById('input-file-id').click();
  }
}
