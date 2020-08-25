import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatSliderModule } from '@angular/material/slider';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {AppRoutingModule } from './app-routing.module';
import {HttpClientModule} from '@angular/common/http';
import {LoginModule} from './login/login.module';
import {UserModule} from './user/user.module';
import { JwtModule } from '@auth0/angular-jwt';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MaterialFileInputModule} from 'ngx-material-file-input';
import {SharedModule} from './shared/shared.module';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import {MatSnackBar} from '@angular/material/snack-bar';
import {MatInputModule} from '@angular/material/input';
import {AgentModule} from './agent/agent.module';
import {AppComponent} from './app.component';
export function tokenGetter(): string {
  return localStorage.getItem('jwt');
}

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    NoopAnimationsModule,
    MatSliderModule,
    MatCardModule,
    MatFormFieldModule,
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    LoginModule,
    MatInputModule,
    AgentModule,
    UserModule,
    HttpClientModule,
    FlexLayoutModule,
    SharedModule,
    MDBBootstrapModule.forRoot(),
    JwtModule.forRoot({
      config: {},
    }),
    MaterialFileInputModule,
    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: ['localhost:52833', 'https://realestate20200708014452.azurewebsites.net', 'realestate20200708014452.azurewebsites.net'],
        blacklistedRoutes: []
      }
    }),
  ],
  providers: [
    MatSnackBar
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
