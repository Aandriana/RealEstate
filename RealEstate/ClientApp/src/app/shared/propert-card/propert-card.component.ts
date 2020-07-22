import {Component, Input, OnInit} from '@angular/core';
import {PropertyListModel} from '../../core/models';

@Component({
  selector: 'app-propert-card',
  templateUrl: './propert-card.component.html',
  styleUrls: ['./propert-card.component.scss']
})
export class PropertCardComponent implements OnInit {
  @Input() property: PropertyListModel;
  constructor() { }
  ngOnInit(): void {
  }
}
