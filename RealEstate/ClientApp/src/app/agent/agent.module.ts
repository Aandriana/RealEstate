import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import {AgentRoutingModule} from './agent-routing.module';



@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    AgentRoutingModule
  ]
})
export class AgentModule { }
