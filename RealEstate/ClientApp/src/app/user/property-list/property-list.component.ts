import {Component, OnInit, ViewChild} from '@angular/core';
import {PropertyService} from '../../core/services/property.service';
import {PropertyListModel} from '../../core/models';
import { MatPaginator } from '@angular/material/paginator';
@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.scss']
})
export class PropertyListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  PropertyListModel: PropertyListModel[];
  pageSize = 16;
  pageNumber = 0;

  constructor(private propertyService: PropertyService) {
  }

  ngOnInit(): void {
    this.getProperties();
  }

  getProperties(): any {
    this.propertyService.getProperties(this.pageNumber, this.pageSize)
      .subscribe((data: PropertyListModel[]) => this.PropertyListModel = data);
  }

  onPageFired(event): any {
    event.pageIndex++;
    this.propertyService.getProperties(event.pageIndex, event.pageSize)
      .subscribe((data: PropertyListModel[]) => this.PropertyListModel = data);
  }
}
