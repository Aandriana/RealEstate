import {Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {PropertyService} from '../../../core/services/property.service';
import {MatDialog} from '@angular/material/dialog';
import {ActivatedRoute, Router} from '@angular/router';
import {PropertyListModel} from '../../../core/models';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import {OfferService} from '../../../core/services/offer.service';
import {NotificationService} from '../../../core/services/notificationService';

@Component({
  selector: 'app-send-offer',
  templateUrl: './send-offer.component.html',
  styleUrls: ['./send-offer.component.scss']
})
export class SendOfferComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  PropertyListModel: PropertyListModel[];
  pageSize = 16;
  pageNumber = 0;
  category: string;
  status: string;
  button = 'Choose';
  id: string;
  propertyId =  new FormArray([]);
  offerForm = new FormGroup({
    agentProfileId: new FormControl('', Validators.required),
    propertyId: this.propertyId
  });

  constructor(private propertyService: PropertyService,
              public dialog: MatDialog,
              private router: Router,
              private route: ActivatedRoute,
              private offerService: OfferService,
              private notificationService: NotificationService) { }
  ngOnInit(): void {
    this.getProperties();
    this.idInit();
  }
  idInit(): void {
    this.route.params.subscribe(value => {
      this.offerForm.patchValue({
        agentProfileId: value.id
      });
    });
  }
    getProperties(): any {
      this.propertyService.getProperties(this.pageNumber, this.pageSize, this.category, this.status)
        .subscribe(data => this.PropertyListModel = data);
    }

    onPageFired(event): any {
      event.pageIndex++;
      this.propertyService.getProperties(event.pageIndex, event.pageSize, this.category, this.status)
        .subscribe(data => this.PropertyListModel = data);
    }
  chooseProperty(id): any{
    const idControl = new FormControl(id);
    for (let i = 0; i < this.propertyId.length; i++) {
      if (this.propertyId.at(i).value === id) {
        this.propertyId.removeAt(i);
        return;
      }
    }
    this.propertyId.push(idControl);
  }
    addOffer(): any{
      this.offerService.sendOfferAsUser(this.offerForm.value).subscribe(res => {
        this.router.navigateByUrl(`home`);
        this.notificationService.success('Offers was added');
      }, err => {
        console.log(err);
        this.notificationService.warn('Something went wrong :(');
      });
    }
}
