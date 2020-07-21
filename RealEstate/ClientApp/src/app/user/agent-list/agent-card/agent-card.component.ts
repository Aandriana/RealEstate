import {Component, Input, OnInit} from '@angular/core';
import {AgentListModel} from '../../../core/models';

@Component({
  selector: 'app-agent-card',
  templateUrl: './agent-card.component.html',
  styleUrls: ['./agent-card.component.scss']
})
export class AgentCardComponent implements OnInit {
  @Input() user: AgentListModel;
  constructor() { }

  ngOnInit(): void {
  }

}
