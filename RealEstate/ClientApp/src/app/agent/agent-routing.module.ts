import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../shared/auth';
import * as __ from './';

const routes: Routes = [
  { path: 'agent', component: __.MainComponent, canActivate: [AuthGuard],  data: { expectedRole: 'Agent'}, children: [
      {path: 'home', component: __.AgentHomeComponent},
      {path: 'properties/:id', component: __.PropertyComponent},
      {path: 'properties', component: __.PropertyListComponent}
    ]}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AgentRoutingModule {}
