import { Component, OnInit } from '@angular/core';
import {UserService} from '../../core/services/user.servicce';
import {AgentById, PropertyByIdModel} from '../../core/models';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-agent-by-id',
  templateUrl: './agent-by-id.component.html',
  styleUrls: ['./agent-by-id.component.scss']
})
export class AgentByIdComponent implements OnInit {
  id: string;
  agent: AgentById;
  button = 'Send offer';

  constructor(private userService: UserService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(value => {
      this.id = value.id;
      this.getAgentById();
    });
  }

  getAgentById(): any {
    this.userService.getAgentById(this.id).subscribe((data: AgentById) => {
      this.agent = data;
      this.agent.feedBacks = data.feedBacks;
    });
  }
}
