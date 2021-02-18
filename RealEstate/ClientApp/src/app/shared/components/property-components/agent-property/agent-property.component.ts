import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {PropertyByIdModel} from '../../../../core/models';

@Component({
  selector: 'app-agent-property',
  templateUrl: './agent-property.component.html',
  styleUrls: ['./agent-property.component.scss']
})
export class AgentPropertyComponent implements OnInit {

  constructor() { }
  @Input() property: PropertyByIdModel;
  @Output() public onComplete: EventEmitter<any> = new EventEmitter();
  ngOnInit(): void {
  }
  buildUrl(slide: string): string {
    return `${slide}`;
  }
  runOnComplete(): void {
    this.onComplete.emit();
  }
  getPhoto(photo: string): string{
    return 'http://localhost:52833/' + photo;
  }
}
