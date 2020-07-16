import {Component, OnInit} from '@angular/core';
import {PropertyService} from '../../core/services/property.service';
import {PropertyListModel} from '../../core/models';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.scss']
})
export class PropertyListComponent implements OnInit {
  PropertyListModel: PropertyListModel[];

  constructor(private propertyService: PropertyService) {
  }

  ngOnInit(): void {
this.getProperties();
  }

  getProperties(): any {
    this.propertyService.getProperties()
      .subscribe((data: PropertyListModel[]) => this.PropertyListModel = data);
  }
}
