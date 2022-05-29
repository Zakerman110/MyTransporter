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

import { SwiperModule } from "swiper/angular";
import { CommentService } from './core/services/comment.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MyaccountComponent } from './components/myaccount/myaccount.component';

import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ServicesComponent,
    MyaccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SwiperModule,
    AuthModule.forRoot({
      config: {
        authority: 'https://localhost:7225',
        redirectUrl: window.location.origin,
        postLogoutRedirectUri: window.location.origin,
        clientId: 'angular',
        scope: 'openid OrderAPI',
        responseType: 'code',
        secureRoutes: ['https://localhost:7192/'],
        logLevel: LogLevel.Debug
      },
    }),
    MatTableModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatInputModule,
    NgbModule
  ],
  providers: [OrderService,
    CommentService,
    {
      provide: HTTP_INTERCEPTORS,
      multi: true,
      useClass: AuthInterceptor
     }
 ],
  bootstrap: [AppComponent]
})
export class AppModule { }
