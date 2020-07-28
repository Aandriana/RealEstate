import {Component, Inject, OnInit, ViewChild} from '@angular/core';
import {PropertyService} from '../../core/services/property.service';
import {Filter, PropertyListModel} from '../../core/models';
import { MatPaginator } from '@angular/material/paginator';
import {MatDialog} from '@angular/material/dialog';
import {DialogPropertyFilterComponent} from '../../shared/dialog-property-filter/dialog-property-filter.component';
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
  category: string;
  status: string;

  constructor(private propertyService: PropertyService, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.getProperties();
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

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogPropertyFilterComponent, {
      width: '250px',
        data: {category: this.category, status: this.status, },
    }).afterClosed()
      .subscribe((item: Filter) => {
        if(item.category != null)
        this.category = item.category;
        this.status = item.status;
        this.getProperties();
      });
  }
}

