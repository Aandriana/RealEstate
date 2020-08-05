import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './main-components/home/home.component';
import {AuthGuard} from '../shared/auth';
import {PropertyListComponent} from './property-components/property-list/property-list.component';
import {AddPropertyComponent} from './property-components/add-property/add-property.component';
import {AgentListComponent} from './agent-components/agent-list/agent-list.component';
import {MainComponent} from './main-components/main/main.component';
import {AddAgentsComponent} from './agent-components/add-agents/add-agents.component';
import {MyProfileComponent} from './profile components/my-profile/my-profile.component';
import {MyProfileEditComponent} from './profile components/my-profile-edit/my-profile-edit.component';
import {PropertyForUserComponent} from './property-components/property-for-user/property-for-user.component';
import {AgentByIdComponent} from './agent-components/agent-details/agent-by-id.component';
import {NotFoundPageComponent} from '../shared/components/shared-components/not-found-page/not-found-page.component';


const routes: Routes = [
  { path: '', component: MainComponent, canActivate: [AuthGuard],  data: { expectedRole: 'User'}, children: [
      {path: 'properties/add/agent', component: AddAgentsComponent},
      {path: 'properties/add', component: AddPropertyComponent},
      {path: 'properties/:id', component: PropertyForUserComponent},
      {path: 'properties', component: PropertyListComponent},
      { path: 'home', component: HomeComponent},
      {path: 'agents', component: AgentListComponent},
      {path: 'agents/:id', component: AgentByIdComponent},
      {path: 'profile', component: MyProfileComponent},
      {path: 'profile/edit', component: MyProfileEditComponent},
      ]
  },
  {path: '404', component: NotFoundPageComponent},
  {path: '**', redirectTo: '/404'}
  ];



@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class UserRoutingModule {}
