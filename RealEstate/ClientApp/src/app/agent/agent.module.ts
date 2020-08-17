import { NgModule } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {ExtendedModule, FlexModule} from '@angular/flex-layout';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {AgentRoutingModule} from './agent-routing.module';
import {CommonModule} from '@angular/common';
import {SharedModule} from '../shared/shared.module';
import {MatPaginatorModule} from '@angular/material/paginator';
import * as __ from './';



@NgModule({
  declarations: [__.ToolbarComponent, __.FooterComponent, __.MainComponent, __.AgentHomeComponent, __.PropertyComponent, __.PropertyListComponent],
  imports: [
    CommonModule,
    AgentRoutingModule,
    MatIconModule,
    MatDividerModule,
    ExtendedModule,
    MatToolbarModule,
    MatMenuModule,
    FlexModule,
    SharedModule,
    MatPaginatorModule
  ]
})
export class AgentModule { }
