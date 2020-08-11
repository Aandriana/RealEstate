import {NgModule} from '@angular/core';
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
import {MatRadioModule} from '@angular/material/radio';
import {MatDialogModule} from '@angular/material/dialog';
import {MDBBootstrapModule} from 'angular-bootstrap-md';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from '../app-routing.module';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatCarouselModule } from '@ngmodule/material-carousel';
import {StarRatingModule} from 'angular-star-rating';
import {MatFormFieldModule} from '@angular/material/form-field';
import * as __ from './index';
import { OffersCardComponent } from './components/property-components/offers-card/offers-card.component';


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
    MatRadioModule,
    MatDialogModule,
    MDBBootstrapModule,
    BrowserModule,
    AppRoutingModule,
    MatCarouselModule,
    MatIconModule,
    MatButtonModule,
    BrowserAnimationsModule,
    MatCarouselModule.forRoot(),
    StarRatingModule.forChild(),
    MatFormFieldModule
  ],
  declarations: [
    __.PropertCardComponent,
    __.AgentCardComponent,
    __.PropertyStatusPipe,
    __.UserProfilePageComponent,
    __.DialogPropertyFilterComponent,
    __.PropertyPageComponent,
    __.OfferCardComponent,
    __.PropertyCategoryPipe,
    __.OfferStatusPipe,
    __.QuestionCardComponent,
    __.RatingComponent,
    __.MatErrorComponent,
    __.AgentProfilePageComponent,
    __.FeedbackCardComponent,
    __.NotFoundPageComponent,
    __.SliderRowComponent,
    OffersCardComponent,
  ],
  exports: [
    __.PropertCardComponent,
    __.AgentCardComponent,
    __.PropertyStatusPipe,
    __.UserProfilePageComponent,
    __.PropertyPageComponent,
    __.PropertyCategoryPipe,
    __.OfferStatusPipe,
    __.MatErrorComponent,
    __.AgentProfilePageComponent,
    __.FeedbackCardComponent,
    __.SliderRowComponent,
    OffersCardComponent,
  ],
  providers: [],
})
export class SharedModule { }
