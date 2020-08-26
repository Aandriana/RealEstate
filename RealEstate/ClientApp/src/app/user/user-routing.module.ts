import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {UserGuard} from '../shared';
import * as __ from './';
import * as ___ from '../shared/';


const routes: Routes = [
  { path: '', component: __.MainComponent, canActivate: [UserGuard], children: [
      {path: 'properties/edit/photos/:id', component: __.EditPropertiesPhotosComponent},
      {path: 'properties/edit/:id', component: __.EditPropertyComponent},
      {path: 'properties/add/agent', component: __.AddAgentsComponent},
      {path: 'properties/:id/offers', component: __.OffersComponent},
      {path: 'properties/:id/questions', component: __.QuestionsEditComponent},
      {path: 'properties/add', component: __.AddPropertyComponent},
      {path: 'properties/:id', component: __.PropertyForUserComponent},
      {path: 'properties', component: __.PropertyListComponent},
      {path: 'profile/edit', component: __.MyProfileEditComponent},
      {path: 'profile', component: __.MyProfileComponent},
      {path: 'agents/feedback/:id', component: __.AddFeedbackComponent},
      {path: 'agents/offer/:id', component: __.SendOfferComponent},
      {path: 'agents/:id', component: __.AgentByIdComponent},
      {path: 'agents', component: __.AgentListComponent},
      { path: 'home', component: __.HomeComponent},
      ]
  },
  {path: '404', component: ___.NotFoundPageComponent},
  {path: '**', redirectTo: '/404'}
  ];



@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class UserRoutingModule {}
