import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
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
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MAT_DATE_LOCALE } from '@angular/material/core';

import {
  NgxMatDatetimePickerModule,
  NgxMatNativeDateModule,
  NgxMatTimepickerModule
} from '@angular-material-components/datetime-picker';

import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OrderDialogBoxComponent } from './components/dialogs/order-dialog-box/order-dialog-box.component';
import { CityService } from './core/services/city.service';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { AdminPanelOrderComponent } from './components/admin-panel-order/admin-panel-order.component';
import { OrderDialogEditBoxComponent } from './components/dialogs/order-dialog-edit-box/order-dialog-edit-box.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ServicesComponent,
    MyaccountComponent,
    OrderDialogBoxComponent,
    AdminPanelComponent,
    AdminPanelOrderComponent,
    OrderDialogEditBoxComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SwiperModule,
    FormsModule,
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
    MatRadioModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    NgxMatDatetimePickerModule,
    NgxMatTimepickerModule,
    NgxMatNativeDateModule,
    MatProgressSpinnerModule,
    NgbModule,
    BrowserAnimationsModule
  ],
  providers: [OrderService,
    CommentService,
    CityService,
    {
      provide: HTTP_INTERCEPTORS,
      multi: true,
      useClass: AuthInterceptor
     },
     { provide: MAT_DATE_LOCALE, useValue: 'en-GB' }
 ],
  bootstrap: [AppComponent]
})
export class AppModule { }
