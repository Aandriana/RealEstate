import { Component, OnInit } from '@angular/core';
import {AgentListModel} from '../../core/models';
import {AgentService} from '../../core/services/agent.service';

@Component({
  selector: 'app-agent-list',
  templateUrl: './agent-list.component.html',
  styleUrls: ['./agent-list.component.scss']
})
export class AgentListComponent implements OnInit {
agentList: AgentListModel[];
  pageSize = 5;
  pageNumber = 0;
  constructor(private agentService: AgentService) { }

  ngOnInit(): void {
    this.getAgents();
  }
  getAgents(): any {
    this.agentService.getAgents(this.pageNumber, this.pageSize)
      .subscribe((data: AgentListModel[]) => this.agentList = data);
  }
  onPageFired(event): any {
    event.pageIndex++;
    this.agentService.getAgents(event.pageIndex, event.pageSize)
      .subscribe((data: AgentListModel[]) => this.agentList = data);
  }

}