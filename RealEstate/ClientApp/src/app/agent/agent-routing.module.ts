import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AgentGuard} from '../shared';
import * as __ from './';

const routes: Routes = [
  { path: 'agent', component: __.MainComponent, canActivate: [AgentGuard], children: [
      {path: 'send/offer/:id', component: __.SendOfferComponent},
      {path: 'home', component: __.AgentHomeComponent},
      {path: 'properties/:id', component: __.PropertyComponent},
      {path: 'properties', component: __.PropertyListComponent},
      {path: 'profile/edit', component: __.MyProfileEditComponent},
      {path: 'profile', component: __.MyProfileComponent},
      {path: 'offers/response/:id', component: __.OfferResponseComponent},
      {path: 'offers', component: __.GetOffersComponent}
    ]}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AgentRoutingModule {}
