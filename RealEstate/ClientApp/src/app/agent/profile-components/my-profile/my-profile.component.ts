import { Component, OnInit } from '@angular/core';
import {AgentById} from '../../../core/models';
import {AgentService} from '../../../core/services/agent.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss']
})
export class MyProfileComponent implements OnInit {
  agent: AgentById;
  button = 'Edit';

  constructor(private agentService: AgentService, private router: Router) {
  }
  ngOnInit(): void {
      this.getMyProfile();
  }

  getMyProfile(): any {
    this.agentService.getMyProfile().subscribe((data: AgentById) => {
      this.agent = data;
    });
  }
  edit(): any{
    this.router.navigateByUrl('agent/profile/edit');
  }
}
