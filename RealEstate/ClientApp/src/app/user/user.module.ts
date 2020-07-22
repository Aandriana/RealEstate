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
import {ReactiveFormsModule} from '@angular/forms';
import {SharedModule} from '../shared/shared.module';
import { MainComponent } from './main/main.component';
import {MatStepperModule} from '@angular/material/stepper';
import {AnimateModule} from '../animate/animate.module';
import {MaterialFileInputModule} from 'ngx-material-file-input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';


@NgModule({
  declarations: [HomeComponent, ToolbarComponent, FooterComponent, PropertyListComponent, AddPropertyComponent, AgentListComponent, MainComponent],
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
    MatInputModule
  ],
  providers: []
})

export class UserModule { }
