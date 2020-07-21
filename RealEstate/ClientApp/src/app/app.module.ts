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
import {MatStepperIntl} from '@angular/material/stepper';
import {AuthGuard} from './shared/auth';
import {MaterialFileInputModule} from 'ngx-material-file-input';
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
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
