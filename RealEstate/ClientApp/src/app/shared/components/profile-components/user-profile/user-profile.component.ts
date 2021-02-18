import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {UserProfile} from '../../../../core/models';

@Component({
  selector: 'app-user-profile-page',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfilePageComponent implements OnInit {
  @Input() user: UserProfile;
  @Input() button: string;
  @Output() public onComplete: EventEmitter<any> = new EventEmitter();
  @Input() completedParam;
  constructor() { }

  ngOnInit(): void {
  }
  runOnComplete(): void {
    this.onComplete.emit(this.completedParam);
  }
  getPhoto(): string {
    return 'http://localhost:52833/' + this.user.imagePath;
  }
}
