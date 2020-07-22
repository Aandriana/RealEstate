import { Component, OnInit } from '@angular/core';
import {AgentListModel} from '../../../core/models';
import {FormArray, FormControl} from '@angular/forms';
import {PropertyService} from '../../../core/services/property.service';
import {AgentService} from '../../../core/services/agent.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-add-agents',
  templateUrl: './add-agents.component.html',
  styleUrls: ['./add-agents.component.scss']
})
export class AddAgentsComponent implements OnInit {
  pageSize = 5;
  pageNumber = 0;
  button = 'Choose';
  agentList: AgentListModel[];
  agentsArray = new FormArray([]);
  constructor(private propertyService: PropertyService, private agentService: AgentService, private router: Router) { }

  ngOnInit(): void {
    this.getAgents();
  }
  onPageFired(event): any {
    event.pageIndex++;
    this.agentService.getAgents(event.pageIndex, event.pageSize)
      .subscribe(data => this.agentList = data);
  }
  addAgent(id): any{
    const idControl = new FormControl(id);
    for (let i = 0; i < this.agentsArray.length; i++) {
      if (this.agentsArray.at(i).value === id) {
        this.agentsArray.removeAt(i);
        return;
      }
    }
    this.agentsArray.push(idControl);
  }
  addProperty(): void{
    const length = this.agentsArray.length;
    this.propertyService.addProperty(length, this.agentsArray).subscribe(res => {
      if (!res) { console.error('error'); }
      this.router.navigateByUrl('/home');
    });
  }
  getAgents(): any {
    this.agentService.getAgents(this.pageNumber, this.pageSize)
      .subscribe(data => this.agentList = data);
  }
}
