import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {AgentListModel} from '../../../../core/models';

@Component({
  selector: 'app-agent-card',
  templateUrl: './agent-card.component.html',
  styleUrls: ['./agent-card.component.scss']
})
export class AgentCardComponent implements OnInit {
  @Input() user: AgentListModel;
  @Input() button: string;
  @Output() public onComplete: EventEmitter<any> = new EventEmitter();
  toggle = true;
  status = 'Enable';

  constructor() { }
  runOnComplete(): void {
    this.onComplete.emit();
  }
  ngOnInit(): void {
  }
  enableDisableRule(): any {
    this.toggle = !this.toggle;
    this.status = this.toggle ? 'Enable' : 'Disable';
  }
  getPhoto(): string {
    return 'http://localhost:52833/' + this.user.imagePath;
  }

}
