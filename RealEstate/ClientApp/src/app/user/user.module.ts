import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
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
import {ReactiveFormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import { MainComponent } from './main/main.component';
import {MatStepperModule} from '@angular/material/stepper';
import {AnimateModule} from '../animate/animate.module';
import {MaterialFileInputModule} from 'ngx-material-file-input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { AddAgentsComponent } from './add-property/add-agents/add-agents.component';
import {MatRadioModule} from '@angular/material/radio';
import { MyProfileComponent } from './my-profile/my-profile.component';
import { MyProfileEditComponent } from './my-profile-edit/my-profile-edit.component';
import { PropertyForUserComponent } from './property-for-user/property-for-user.component';
import {StarRatingModule} from 'angular-star-rating';
import { AgentByIdComponent } from './agent-by-id/agent-by-id.component';


@NgModule({
  declarations: [HomeComponent, ToolbarComponent, FooterComponent, PropertyListComponent, AddPropertyComponent, AgentListComponent, MainComponent, AddAgentsComponent, MyProfileComponent, MyProfileEditComponent, PropertyForUserComponent, AgentByIdComponent],
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
        AnimateModule,
        MaterialFileInputModule,
        MatInputModule,
        MatRadioModule,
        StarRatingModule.forRoot()
    ],
  providers: [],
})

export class UserModule { }
