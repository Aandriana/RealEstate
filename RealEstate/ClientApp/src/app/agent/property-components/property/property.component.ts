import { Component, OnInit } from '@angular/core';
import {PropertyByIdModel} from '../../../core/models';
import {PropertyService} from '../../../core/services/property.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.scss']
})
export class PropertyComponent implements OnInit {
  propertyId: any;
  propertyDetails: PropertyByIdModel;
  constructor(private route: ActivatedRoute, private properyService: PropertyService, private router: Router) { }

  getPropertyById(): any{
    this.properyService.getPropertyForAgent(this.propertyId).subscribe((data: PropertyByIdModel) => {
      this.propertyDetails = data;
    });
  }
  ngOnInit(): void {
    this.route.params.subscribe(value => {
      this.propertyId = value.id;
      this.getPropertyById();
    });
  }
  sendOffer(): any{
    this.router.navigateByUrl(`agent/send/offer/${this.propertyId}`);
  }
}
