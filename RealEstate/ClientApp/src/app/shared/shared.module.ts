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
import { MatCarouselModule } from '@ngmodule/material-carousel';
import {MatFormFieldModule} from '@angular/material/form-field';
import * as __ from './';
import {MatExpansionModule} from '@angular/material/expansion';
import {RatingModule} from 'ng-starrating';
import {MatInputModule} from '@angular/material/input';
import {RouterModule} from '@angular/router';


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
    MatCarouselModule,
    MatIconModule,
    MatButtonModule,
    MatCarouselModule.forRoot(),
    MatFormFieldModule,
    MatExpansionModule,
    RatingModule,
    MatInputModule,
    RouterModule
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
    __.OffersCardComponent,
    __.QuestionAnswerComponent,
    __.QuestionsCardComponent,
    __.DialogDeletingSureComponent,
    __.DialogEditQuestionComponent,
    __.DialogAddQuestionComponent,
    __.AgentPropertyComponent,
    __.GetOfferCardForAgentComponent,
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
        __.OffersCardComponent,
        __.QuestionsCardComponent,
        __.GetOfferCardForAgentComponent,
        __.AgentPropertyComponent,
    ],
  providers: [],
})
export class SharedModule { }
