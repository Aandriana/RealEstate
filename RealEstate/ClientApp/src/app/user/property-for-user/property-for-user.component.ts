import { Component, OnInit } from '@angular/core';
import {PropertyByIdModel} from '../../core/models';
import {ActivatedRoute} from '@angular/router';
import {PropertyService} from '../../core/services/property.service';

@Component({
  selector: 'app-property-for-user',
  templateUrl: './property-for-user.component.html',
  styleUrls: ['./property-for-user.component.scss']
})
export class PropertyForUserComponent implements OnInit {
  propertyId: number;
  propertyDetails: PropertyByIdModel;

  constructor(private route: ActivatedRoute, private properyService: PropertyService) { }

  ngOnInit(): void {
    this.propertyId = parseInt(this.route.snapshot.paramMap.get('Id'));
    this.getNewsById(this.propertyId);
  }
  getNewsById(id): any{
    this.properyService.getPropertyById(id).subscribe((data: PropertyByIdModel) => {
      this.propertyDetails = data;
    });
  }

}
