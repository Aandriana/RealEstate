import {Component, Input, OnInit} from '@angular/core';
import {PropertyByIdModel} from '../../../../core/models';

@Component({
  selector: 'app-agent-property',
  templateUrl: './agent-property.component.html',
  styleUrls: ['./agent-property.component.scss']
})
export class AgentPropertyComponent implements OnInit {

  constructor() { }
  @Input() property: PropertyByIdModel;
  ngOnInit(): void {
  }
  buildUrl(slide: string): string {
    return `${slide}`;
  }

}
