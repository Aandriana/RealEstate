import {Component, Input, OnInit} from '@angular/core';
import {OfferResponseViewModel, OffersListModel} from '../../../../core/models';
import {OfferService} from '../../../../core/services/offer.service';
import {Router} from '@angular/router';
import {NotificationService} from '../../../../core/services/notificationService';
import {UserService} from '../../../../core/services/user.servicce';

@Component({
  selector: 'app-offers-card',
  templateUrl: './offers-card.component.html',
  styleUrls: ['./offers-card.component.scss']
})
export class OffersCardComponent implements OnInit {
  @Input() offer: OffersListModel;
  panelOpenState = false;
  constructor(private offerService: OfferService, private router: Router, private notificationService: NotificationService, private userService: UserService) { }

  ngOnInit(): void {
  }
  sendResponse(status, id, propertyId): any{
    const responce = new OfferResponseViewModel(status);
    return this.offerService.responseFromUser(id, responce).subscribe(res => {
      this.router.navigateByUrl(`properties/${propertyId}/offers`);
      this.notificationService.success('Response has been sent');
    });
  }
  addFeedback(status, id, agentId): any{
    const responce = new OfferResponseViewModel(status);
    return this.offerService.responseFromUser(id, responce).subscribe(() => {
    this.router.navigateByUrl( `agents/feedback/${agentId}`);
  });
  }
  getPhoto(): string {
    return 'http://localhost:52833/' + this.offer.image;
  }
}
