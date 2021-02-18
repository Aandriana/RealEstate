import { Component, OnInit } from '@angular/core';
import {UserService} from '../../../core/services/user.servicce';
import {AgentById, PropertyByIdModel} from '../../../core/models';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-agent-by-id',
  templateUrl: './agent-details.html',
  styleUrls: ['./agent-details.scss']
})
export class AgentByIdComponent implements OnInit {
  id: string;
  agent: AgentById;
  button = 'Send offer';

  constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) {
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
    });
  }
  sendOffret(): any{
    this.router.navigateByUrl(`agents/offer/${this.id}`);
  }
}
