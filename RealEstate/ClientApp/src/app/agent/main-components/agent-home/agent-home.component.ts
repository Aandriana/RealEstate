import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-agent-home',
  templateUrl: './agent-home.component.html',
  styleUrls: ['./agent-home.component.scss']
})
export class AgentHomeComponent implements OnInit {

  constructor( private router: Router) { }

  ngOnInit(): void {
  }
properties(): any{
    this.router.navigateByUrl('agent/properties');
}
}
