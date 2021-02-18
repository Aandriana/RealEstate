import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {PropertyService} from '../../../core/services/property.service';
import {PropertyByIdModel} from '../../../core/models';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-edit-property',
  templateUrl: './edit-property.component.html',
  styleUrls: ['./edit-property.component.scss']
})
export class EditPropertyComponent implements OnInit {
id: number;
property: PropertyByIdModel;
  constructor(private propertyService: PropertyService, private route: ActivatedRoute, private router: Router) { }
  editPropertyForm = new FormGroup({
    size: new FormControl('', [Validators.required,  Validators.pattern(/^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$/)]),
    category: new FormControl(''),
    floorsNumber: new FormControl('', [Validators.required, Validators.pattern(/(?:\s|^)\d+(?=\s|$)/)]),
    floors: new FormControl('', [Validators.required,  Validators.pattern(/(?:\s|^)\d+(?=\s|$)/)]),
    price: new FormControl('', [Validators.required, Validators.pattern(/^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$/)]),
    city: new FormControl('', Validators.required),
    address: new FormControl('', Validators.required),
    buildYear: new FormControl('', Validators.required),
  });

  ngOnInit(): void {
    this.route.params.subscribe(value => {
      this.id = value.id;
      this.propertyService.getPropertyById(this.id).subscribe(res => {
        this.property = res as PropertyByIdModel;
        this.editPropertyForm.setValue({
          size: this.property.size,
          category: this.property.category,
          floorsNumber: this.property.floorsNumber,
          floors: this.property.floors,
          price: this.property.price,
          city: this.property.city,
          address: this.property.address,
          buildYear: this.property.buildYear
        });
      });
    });
  }
  confirm(): any{
    this.propertyService.editProperty(this.id, this.editPropertyForm.value).subscribe(res => {
      this.router.navigateByUrl(`/properties/${this.id}`);
    });
  }
}
