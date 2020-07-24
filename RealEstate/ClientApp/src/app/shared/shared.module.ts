import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatDividerModule} from '@angular/material/divider';
import {ExtendedModule, FlexModule} from '@angular/flex-layout';
import {MatButtonModule} from '@angular/material/button';
import {NgsRevealModule} from 'ngx-scrollreveal';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import {ReactiveFormsModule} from '@angular/forms';
import {PropertCardComponent} from './propert-card/propert-card.component';
import {AgentCardComponent} from './agent-card/agent-card.component';
import {SharedRoutingModule} from './shared-routing.module';
import {PropertyStatusPipe} from './pipes/property-status-pipe';
import { UserProfilePageComponent } from './user-profile-page/user-profile-page.component';


@NgModule({
  imports: [
    CommonModule,
    MatMenuModule,
    MatIconModule,
    MatToolbarModule,
    MatDividerModule,
    ExtendedModule,
    FlexModule,
    MatButtonModule,
    NgsRevealModule,
    MatPaginatorModule,
    MatCardModule,
    MatGridListModule,
    ReactiveFormsModule,
    SharedRoutingModule
  ],
  declarations: [PropertCardComponent, AgentCardComponent, PropertyStatusPipe, UserProfilePageComponent],
    exports: [PropertCardComponent, AgentCardComponent, PropertyStatusPipe, UserProfilePageComponent],
  providers: []
})
export class SharedModule { }
