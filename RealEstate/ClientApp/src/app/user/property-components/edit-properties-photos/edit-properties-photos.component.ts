import { Component, OnInit } from '@angular/core';
import {PropertyService} from '../../../core/services/property.service';
import {ActivatedRoute, Router} from '@angular/router';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-edit-properties-photos',
  templateUrl: './edit-properties-photos.component.html',
  styleUrls: ['./edit-properties-photos.component.scss']
})
export class EditPropertiesPhotosComponent implements OnInit {
  photos: string[] = [];
   id: number;
  editPropertyForm = new FormGroup({
    addedContentImages: new FormControl(null)
  });
  constructor(private propertyService: PropertyService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(value => {
      this.id = value.id;
      this.propertyService.getPhotos(this.id).subscribe(res => {
        this.photos = res as string[];
      });
    });
  }

  onRemove(toRemoveUrl: string): any {
    const index = this.photos.indexOf(toRemoveUrl);
    if (index !== -1) {
      this.photos.splice(index, 1);
    }
  }
  submit(): any {
    this.propertyService.editPhotos(this.id, this.editPropertyForm, this.photos).subscribe(res => {
      this.router.navigateByUrl(`/properties/${this.id}`);
    });
  }
  getPhoto(photo: string): string {
    return 'http://localhost:52833/' + photo;
  }
}
