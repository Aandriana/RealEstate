import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatSliderModule } from '@angular/material/slider';
import { AppComponent } from './app.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import {ReactiveFormsModule} from '@angular/forms';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import { AppRoutingModule } from './app-routing.module';
import {HttpClientModule} from '@angular/common/http';
import {LoginModule} from './login/login.module';
import {UserModule} from './user/user.module';
import { JwtModule } from '@auth0/angular-jwt';
import { FlexLayoutModule } from '@angular/flex-layout';
import {AuthGuard} from './shared/auth';
import {MaterialFileInputModule} from 'ngx-material-file-input';
import {SharedModule} from './shared/shared.module';
import {AgentModule} from './agent/agent.module';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import {MatSnackBar} from '@angular/material/snack-bar';
import {StarRatingModule} from 'angular-star-rating';
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
    UserModule,
    HttpClientModule,
    FlexLayoutModule,
    SharedModule,
    AgentModule,
    StarRatingModule.forRoot(),
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
    AuthGuard,
    MatSnackBar
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
