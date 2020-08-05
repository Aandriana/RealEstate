import { Component, OnInit } from '@angular/core';
import {PropertyByIdModel} from '../../../core/models';
import {ActivatedRoute} from '@angular/router';
import {PropertyService} from '../../../core/services/property.service';

@Component({
  selector: 'app-property-for-user',
  templateUrl: './property-for-user.component.html',
  styleUrls: ['./property-for-user.component.scss']
})
export class PropertyForUserComponent implements OnInit {
  propertyId: any;
  propertyDetails: PropertyByIdModel;

  constructor(private route: ActivatedRoute, private properyService: PropertyService) { }
  getPropertyById(): any{
    this.properyService.getPropertyById(this.propertyId).subscribe((data: PropertyByIdModel) => {
      this.propertyDetails = data;
    });
  }
  ngOnInit(): void {
      this.route.params.subscribe(value => {
        this.propertyId = value.id;
        console.log(this.propertyId);
        this.getPropertyById();
      });
  }
}
