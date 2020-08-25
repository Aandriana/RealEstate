import { Component, OnInit } from '@angular/core';
import {PropertyByIdModel} from '../../../core/models';
import {ActivatedRoute, Router} from '@angular/router';
import {PropertyService} from '../../../core/services/property.service';

@Component({
  selector: 'app-property-for-user',
  templateUrl: './property-for-user.component.html',
  styleUrls: ['./property-for-user.component.scss']
})
export class PropertyForUserComponent implements OnInit {
  propertyId: any;
  propertyDetails: PropertyByIdModel;
  deleted = false;

  constructor(private route: ActivatedRoute, private properyService: PropertyService, private router: Router) { }
  getPropertyById(): any{
    this.properyService.getPropertyById(this.propertyId).subscribe((data: PropertyByIdModel) => {
      this.propertyDetails = data;
    });
  }
  ngOnInit(): void {
      this.route.params.subscribe(value => {
        this.propertyId = value.id;
        this.getPropertyById();
      });
  }
  editProperty(): any{
    this.router.navigateByUrl(`properties/edit/${this.propertyId}`);
  }
  editPropertyPhotos(): any{
    this. router.navigateByUrl(`properties/edit/photos/${this.propertyId}`);
  }
  deleteProperty(): any {
    if (!this.deleted) {
      return this.properyService.deleteProperty(this.propertyId).subscribe(res => {
        this.deleted = true;
        this.router.navigateByUrl(`/properties/${this.propertyId}`);
        this.ngOnInit();
      });
    } else {
      return this.properyService.restoreProperty(this.propertyId).subscribe(res => {
        this.deleted = false;
        this.ngOnInit();
      });
    }
  }
  showOffers(): any{
    this.router.navigateByUrl(`/properties/${this.propertyId}/offers`);
  }
  showQuestions(): any{
    this.router.navigateByUrl(`/properties/${this.propertyId}/questions`);
  }
  getButton(): string {
    return this.deleted ? 'Restore' : 'Delete';
  }
}
