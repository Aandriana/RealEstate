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
import {PropertCardComponent} from './propert-card/propert-card.component';
import {AgentCardComponent} from './agent-card/agent-card.component';
import {PropertyStatusPipe} from './pipes/property-status-pipe';
import { UserProfilePageComponent } from './user-profile-page/user-profile-page.component';
import { DialogPropertyFilterComponent } from './dialog-property-filter/dialog-property-filter.component';
import {MatRadioModule} from '@angular/material/radio';
import {MatDialogModule} from '@angular/material/dialog';
import { PropertyPageComponent } from './property-page/property-page.component';
import {MDBBootstrapModule} from 'angular-bootstrap-md';
import {BrowserModule} from '@angular/platform-browser';
import {AppRoutingModule} from '../app-routing.module';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatCarouselModule } from '@ngmodule/material-carousel';
import { OfferCardComponent } from './offer-card/offer-card.component';
import {PropertyCategoryPipe} from './pipes/property-category.pipe';
import {OfferStatusPipe} from './pipes/offer-status.pipe';
import { QuestionCardComponent } from './question-card/question-card.component';
import { RatingComponent } from './rating/rating.component';
import {StarRatingModule} from 'angular-star-rating';
import { MatErrorComponent } from './mat-error/mat-error.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import { AgentProfilePageComponent } from './agent-profile-page/agent-profile-page.component';
import { FeedbackCardComponent } from './feedback-card/feedback-card.component';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';


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
    StarRatingModule.forRoot(),
    MatFormFieldModule
  ],
  declarations: [PropertCardComponent, AgentCardComponent, PropertyStatusPipe, UserProfilePageComponent, DialogPropertyFilterComponent, PropertyPageComponent, OfferCardComponent, PropertyCategoryPipe, OfferStatusPipe, QuestionCardComponent, RatingComponent, MatErrorComponent, AgentProfilePageComponent, FeedbackCardComponent, NotFoundPageComponent],
  exports: [PropertCardComponent, AgentCardComponent, PropertyStatusPipe, UserProfilePageComponent, PropertyPageComponent, PropertyCategoryPipe, OfferStatusPipe, MatErrorComponent, AgentProfilePageComponent, FeedbackCardComponent],
  providers: [],
})
export class SharedModule { }
