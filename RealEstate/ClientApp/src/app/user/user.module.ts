import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {UserRoutingModule} from './user-routing.module';
import { HomeComponent } from './home/home.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatDividerModule} from '@angular/material/divider';
import {ExtendedModule, FlexModule} from '@angular/flex-layout';
import {MatButtonModule} from '@angular/material/button';
import { FooterComponent } from './footer/footer.component';
import {NgsRevealModule} from 'ngx-scrollreveal';
import { PropertyListComponent } from './property-list/property-list.component';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import { AddPropertyComponent } from './add-property/add-property.component';
import { AgentListComponent } from './agent-list/agent-list.component';
import { PropertCardComponent } from './property-list/propert-card/propert-card.component';
import { AgentCardComponent } from './agent-list/agent-card/agent-card.component';
import {ReactiveFormsModule} from '@angular/forms';


@NgModule({
  declarations: [HomeComponent, ToolbarComponent, FooterComponent, PropertyListComponent, AddPropertyComponent, AgentListComponent, PropertCardComponent, AgentCardComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
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
  ],
  providers: []
})

export class UserModule { }
