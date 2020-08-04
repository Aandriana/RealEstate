import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {AuthGuard} from '../shared/auth';
import {MainComponent} from './main/main.component';

const routes: Routes = [
  {path: '', component: MainComponent, canActivate: [AuthGuard],  data: {
      expectedRole: 'Agent'
    }, children: [
      { path: 'agent/home', component: HomeComponent }
    ]}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AgentRoutingModule {}
