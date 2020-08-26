import { Component, OnInit } from '@angular/core';
import {UserService} from '../../../core/services/user.servicce';
import {ActivatedRoute, Router} from '@angular/router';
import {FormControl, FormGroup} from '@angular/forms';
import {NotificationService} from '../../../core/services/notificationService';
import {StarRatingComponent} from 'ng-starrating';

@Component({
  selector: 'app-add-feedback',
  templateUrl: './add-feedback.component.html',
  styleUrls: ['./add-feedback.component.scss']
})
export class AddFeedbackComponent implements OnInit {
  feedbackForm = new FormGroup({
    rating: new FormControl(''),
    comment: new FormControl(''),
    agentId: new FormControl('')
  });
  agentId: string;
  constructor(private userService: UserService,
              private route: ActivatedRoute,
              private router: Router,
              private notificationService: NotificationService) {}
  ngOnInit(): void {
    this.route.params.subscribe(value => {
      this.agentId = value.id;
      this.feedbackForm.patchValue({
        agentId: this.agentId
      });
    });
  }
  sendFeedback(): any {
    this.userService.addFeedback(this.feedbackForm.value).subscribe(() => {
      this.router.navigateByUrl(`agents/${this.agentId}`);
      this.notificationService.success('feedback was send');
    });
  }
  onRate($event: {oldValue: number, newValue: number, starRating: StarRatingComponent}): any {
    this.feedbackForm.patchValue({
      rating: $event.newValue
    });
  }
}
