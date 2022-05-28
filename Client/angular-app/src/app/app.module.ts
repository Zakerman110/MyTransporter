import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthInterceptor, AuthModule, LogLevel } from 'angular-auth-oidc-client';

import { OrderService } from './core/services/order.service';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { ServicesComponent } from './components/services/services.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ServicesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AuthModule.forRoot({
      config: {
        authority: 'https://localhost:7225',
        redirectUrl: window.location.origin,
        postLogoutRedirectUri: window.location.origin,
        clientId: 'angular',
        scope: 'openid OrderAPI',
        responseType: 'code',
        secureRoutes: ['https://localhost:7192/'],
        logLevel: LogLevel.Debug,
      },
    })
  ],
  providers: [OrderService,
    {
      provide: HTTP_INTERCEPTORS,
      multi: true,
      useClass: AuthInterceptor
     }
 ],
  bootstrap: [AppComponent]
})
export class AppModule { }
