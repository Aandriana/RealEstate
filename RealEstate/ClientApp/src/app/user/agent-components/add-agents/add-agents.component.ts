import { Component, OnInit } from '@angular/core';
import {AgentListModel} from '../../../core/models';
import {FormArray, FormControl} from '@angular/forms';
import {PropertyService} from '../../../core/services/property.service';
import {AgentService} from '../../../core/services/agent.service';
import {Router} from '@angular/router';
import {NotificationService} from '../../../core/services/notificationService';

@Component({
  selector: 'app-add-agents',
  templateUrl: './add-agents.component.html',
  styleUrls: ['./add-agents.component.scss']
})
export class AddAgentsComponent implements OnInit {
  pageSize = 25;
  pageNumber = 0;
  button = 'Choose';
  agentList: AgentListModel[];
  agentsArray = new FormArray([]);
  constructor(private propertyService: PropertyService, private agentService: AgentService, private router: Router, private notificationService: NotificationService) { }

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
      this.router.navigateByUrl('/home');
    }, err => {
      console.log(err);
      this.notificationService.warn('Some data must be incorrect. Please, check it.');
    });
  }
  getAgents(): any {
    this.agentService.getAgents(this.pageNumber, this.pageSize)
      .subscribe(data => this.agentList = data);
  }
}
