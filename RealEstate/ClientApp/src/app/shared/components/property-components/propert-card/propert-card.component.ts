import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {PropertyListModel} from '../../../../core/models';
import {Router} from '@angular/router';

@Component({
  selector: 'app-propert-card',
  templateUrl: './propert-card.component.html',
  styleUrls: ['./propert-card.component.scss']
})
export class PropertCardComponent implements OnInit {
  @Input() property: PropertyListModel;
  @Output() public onComplete: EventEmitter<any> = new EventEmitter();
  constructor() { }
  ngOnInit(): void {
  }
  runOnComplete(): void {
    this.onComplete.emit();
  }
}
