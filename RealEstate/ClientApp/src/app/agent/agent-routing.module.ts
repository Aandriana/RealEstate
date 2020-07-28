import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {AuthGuard} from '../shared/auth';

const routes: Routes = [
  { path: 'agent/home', component: HomeComponent , canActivate: [AuthGuard],  data: {
    expectedRole: 'Agent'
  } },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AgentRoutingModule {}
