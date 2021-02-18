import { Component, OnInit } from '@angular/core';
import {OfferResponseViewModel, OffersListModel} from '../../../core/models';
import {OfferService} from '../../../core/services/offer.service';
import {Router} from '@angular/router';
import {NotificationService} from '../../../core/services/notificationService';

@Component({
  selector: 'app-get-offers',
  templateUrl: './get-offers.component.html',
  styleUrls: ['./get-offers.component.scss']
})
export class GetOffersComponent implements OnInit {
  offers: OffersListModel[];
  pageSize = 5;
  pageNumber = 0;
  status = 0;
  offerStatuses = ['From customer', 'To customer', 'Confirmed', 'Declined', 'Sold', 'Failed'];
  constructor(private offerService: OfferService, private router: Router, private notificationService: NotificationService) { }
  ngOnInit(): void {
      this.offerService.getOffersForAgetn(this.pageNumber, this.pageSize, this.status).subscribe((data: OffersListModel[]) => {
        this.offers = data;
  });
  }
  async filter(offerStatus): Promise<any> {
    this.status = offerStatus.index;
    await this.ngOnInit();
  }
  onPageFired(event): any {
    event.pageIndex++;
    this.offerService.getOffersForAgetn(event.pageIndex, event.pageSize, this.status)
      .subscribe(data => this.offers = data);
  }
  accept(id): any{
    const response = new OfferResponseViewModel(2);
    return this.offerService.agentResponse(id, response).subscribe(res => {
      this.router.navigateByUrl(`agent/offers`);
      this.notificationService.success('Response has been sent');
    });
  }
  decline(id): any{
    const response = new OfferResponseViewModel(3);
    return this.offerService.agentResponse(id, response).subscribe(res => {
      this.router.navigateByUrl(`agent/offers`);
      this.notificationService.success('Response has been sent');
    });
  }
}
