import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {AgentListModel} from '../../core/models';

@Component({
  selector: 'app-agent-card',
  templateUrl: './agent-card.component.html',
  styleUrls: ['./agent-card.component.scss']
})
export class AgentCardComponent implements OnInit {
  @Input() user: AgentListModel;
  @Input() button: string;
  @Output() public onComplete: EventEmitter<any> = new EventEmitter();
  @Input() completedParam;
  toggle = true;
  status = 'Enable';

  enableDisableRule(): any {
    this.toggle = !this.toggle;
    this.status = this.toggle ? 'Enable' : 'Disable';
  }
  constructor() { }
  runOnComplete(): void {
    this.onComplete.emit(this.completedParam);
  }
  ngOnInit(): void {
  }

}
