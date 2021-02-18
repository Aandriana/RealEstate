import { NgModule } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {ExtendedModule, FlexModule} from '@angular/flex-layout';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {AgentRoutingModule} from './agent-routing.module';
import {CommonModule} from '@angular/common';
import {SharedModule} from '../shared/shared.module';
import {MatPaginatorModule} from '@angular/material/paginator';
import * as __ from './';
import {ReactiveFormsModule} from '@angular/forms';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatTabsModule} from '@angular/material/tabs';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import { OfferResponseComponent } from './offer-components/offer-response/offer-response.component';



@NgModule({
  declarations: [__.ToolbarComponent, __.FooterComponent, __.MainComponent, __.AgentHomeComponent, __.PropertyComponent, __.PropertyListComponent, __.MyProfileComponent, __.MyProfileEditComponent, __.SendOfferComponent, __.GetOffersComponent, OfferResponseComponent],
  imports: [
    CommonModule,
    AgentRoutingModule,
    MatIconModule,
    MatDividerModule,
    ExtendedModule,
    MatToolbarModule,
    MatMenuModule,
    FlexModule,
    SharedModule,
    MatPaginatorModule,
    ReactiveFormsModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatTabsModule,
    NoopAnimationsModule
  ]
})
export class AgentModule { }
