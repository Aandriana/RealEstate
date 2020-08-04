import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import {AgentRoutingModule} from './agent-routing.module';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { FooterComponent } from './footer/footer.component';
import { MainComponent } from './main/main.component';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {ExtendedModule} from '@angular/flex-layout';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';



@NgModule({
  declarations: [HomeComponent, ToolbarComponent, FooterComponent, MainComponent],
  imports: [
    CommonModule,
    AgentRoutingModule,
    MatIconModule,
    MatDividerModule,
    ExtendedModule,
    MatToolbarModule,
    MatMenuModule
  ]
})
export class AgentModule { }
