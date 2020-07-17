import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {AuthGuard} from '../shared/auth';
import {PropertyListComponent} from './property-list/property-list.component';
import {AddPropertyComponent} from './add-property/add-property.component';
import {AgentListComponent} from './agent-list/agent-list.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent , canActivate: [AuthGuard],  data: {
      expectedRole: 'User'
    } },
  {path: 'properties', component: PropertyListComponent, canActivate: [AuthGuard], data: {
      expectedRole: 'User'
    }},
  {path: 'property/add', component: AddPropertyComponent, canActivate: [AuthGuard], data: {
      expectedRole: 'User'
    }},
  {path: 'agents', component: AgentListComponent, canActivate: [AuthGuard], data: {
      expectedRole: 'User'
    }}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class UserRoutingModule {}
