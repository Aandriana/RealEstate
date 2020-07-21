import {Component, Input, OnInit} from '@angular/core';
import {PropertyListModel, PropertyStatus} from '../../../core/models';

@Component({
  selector: 'app-propert-card',
  templateUrl: './propert-card.component.html',
  styleUrls: ['./propert-card.component.scss']
})
export class PropertCardComponent implements OnInit {
  @Input() property: PropertyListModel;
  @Input() Status: PropertyStatus;
  status = this.Status;
  constructor() { }
  ngOnInit(): void {
  }
getStatus(): string{
    if (this.property.status === 0) { return 'Frozen'; }
    if (this.property.status === 1) { return 'Looking for agent'; }
    if (this.property.status === 2) { return 'Found agent'; }
    if (this.property.status === 3) { return 'Sold'; }
}
}
