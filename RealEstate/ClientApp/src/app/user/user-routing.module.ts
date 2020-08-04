import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {AuthGuard} from '../shared/auth';
import {PropertyListComponent} from './property-list/property-list.component';
import {AddPropertyComponent} from './add-property/add-property.component';
import {AgentListComponent} from './agent-list/agent-list.component';
import {MainComponent} from './main/main.component';
import {AddAgentsComponent} from './add-property/add-agents/add-agents.component';
import {MyProfileComponent} from './my-profile/my-profile.component';
import {MyProfileEditComponent} from './my-profile-edit/my-profile-edit.component';
import {PropertyForUserComponent} from './property-for-user/property-for-user.component';
import {AgentByIdComponent} from './agent-by-id/agent-by-id.component';
import {NotFoundPageComponent} from '../shared/not-found-page/not-found-page.component';


const routes: Routes = [
  { path: '', component: MainComponent, canActivate: [AuthGuard],  data: { expectedRole: 'User'}, children: [
      {path: 'property/:id', component: PropertyForUserComponent},
      { path: 'home', component: HomeComponent},
      {path: 'properties', component: PropertyListComponent},
      {path: 'add/property', component: AddPropertyComponent},
      {path: 'agents', component: AgentListComponent},
      {path: 'property/add/agents', component: AddAgentsComponent},
      {path: 'profile', component: MyProfileComponent},
      {path: 'profile/edit', component: MyProfileEditComponent},
      {path: 'agent/:id', component: AgentByIdComponent}
      ]
  },
  {path: '404', component: NotFoundPageComponent},
  {path: '**', redirectTo: '/404'}
  ];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class UserRoutingModule {}
