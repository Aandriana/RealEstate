import {Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {PropertyService} from '../../../core/services/property.service';
import {MatDialog} from '@angular/material/dialog';
import {PropertyListModel} from '../../../core/models';
import {Router} from '@angular/router';

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
  button = 'More details';

  constructor(private propertyService: PropertyService, public dialog: MatDialog, private router: Router) {
  }

  ngOnInit(): void {
    this.getProperties();
  }

  getProperties(): any {
    this.propertyService.getPropertiesforAgent(this.pageNumber, this.pageSize)
      .subscribe(data => this.PropertyListModel = data);
  }

  onPageFired(event): any {
    event.pageIndex++;
    this.propertyService.getPropertiesforAgent(event.pageIndex, event.pageSize)
      .subscribe(data => this.PropertyListModel = data);
  }

  chooseProperty(id): void{
    this.router.navigateByUrl(`agent/properties/${id}`);
  }
}

