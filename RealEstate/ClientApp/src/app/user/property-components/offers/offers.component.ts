import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {OffersListModel} from '../../../core/models';
import {PropertyService} from '../../../core/services/property.service';

@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.scss']
})
export class OffersComponent implements OnInit {
  propertyId: any;
  offers: OffersListModel[];
  pageSize = 5;
  pageNumber = 0;
  status = 0;
  offerStatuses = ['To agent', 'From agent', 'Confirmed', 'Declined', 'Sold', 'Failed'];
  constructor(private route: ActivatedRoute, private propertyService: PropertyService) { }

  onPageFired(event): any {
    event.pageIndex++;
    this.propertyService.getOffersToProperty(this.propertyId, event.pageIndex, event.pageSize, this.status)
      .subscribe(data => this.offers = data);
  }
  ngOnInit(): void {
    this.route.params.subscribe(value => {
      this.propertyId = value.id;
      this.propertyService.getOffersToProperty(this.propertyId, this.pageNumber, this.pageSize, this.status).subscribe((data: OffersListModel[]) => {
        this.offers = data;
      });
    });
  }
filter(offerStatus): any{
    this.status = offerStatus.index;
    this.ngOnInit();
  }
}
