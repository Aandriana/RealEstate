import {NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import {UserRoutingModule} from './user-routing.module';
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
import {SharedModule} from '../shared/shared.module';
import {MatStepperModule} from '@angular/material/stepper';
import {MaterialFileInputModule} from 'ngx-material-file-input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatRadioModule} from '@angular/material/radio';
import * as __ from './';
import {MatTabsModule} from '@angular/material/tabs';
import {RatingModule} from 'ng-starrating';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
        __.HomeComponent,
        __.ToolbarComponent,
        __.FooterComponent,
        __.PropertyListComponent,
        __.AddPropertyComponent,
        __.AgentListComponent,
        __.MainComponent,
        __.AddAgentsComponent,
        __.MyProfileComponent,
        __.MyProfileEditComponent,
        __.PropertyForUserComponent,
        __.AgentByIdComponent,
        __.EditPropertyComponent,
        __.EditPropertiesPhotosComponent,
        __.OffersComponent,
        __.QuestionsEditComponent,
        __.SendOfferComponent
  ],
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
    SharedModule,
    MatStepperModule,
    MatFormFieldModule,
    MaterialFileInputModule,
    MatInputModule,
    MatRadioModule,
    MatTabsModule,
    RatingModule,
    NoopAnimationsModule
  ],
  providers: [],
})

export class UserModule { }
