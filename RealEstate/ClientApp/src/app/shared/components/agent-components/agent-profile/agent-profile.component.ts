import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {AgentById} from '../../../../core/models';

@Component({
  selector: 'app-agent-profile-page',
  templateUrl: './agent-profile.component.html',
  styleUrls: ['./agent-profile.component.scss']
})
export class AgentProfilePageComponent implements OnInit {
  @Input() agentProfile: AgentById;
  @Input() buttonTitle: string;
  @Output() public onComplete: EventEmitter<any> = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }
  runOnComplete(): void {
    this.onComplete.emit();
  }
}
