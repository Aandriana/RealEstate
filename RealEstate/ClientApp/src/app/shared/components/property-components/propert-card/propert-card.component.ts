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
  @Input() buttonName: string;
  toggle = true;
  status = 'Enable';
  constructor() { }
  ngOnInit(): void {
  }
  runOnComplete(): void {
    this.onComplete.emit();
  }
  enableDisableRule(): any {
    this.toggle = !this.toggle;
    this.status = this.toggle ? 'Enable' : 'Disable';
  }
  getPhoto(): string {
    return 'http://localhost:52833/' + this.property.image;
  }
}
