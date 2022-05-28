import { Component } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { order } from './core/models/order';
import { OrderService } from './core/services/order.service';
import {AuthService} from "./core/services/auth.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public oidcSecurityService: OidcSecurityService, 
              public http: HttpClient, 
              public orderService: OrderService,
              private authService: AuthService) {}

  isAuth: boolean = false;
  isAdmin: boolean = false;
  role: string = '';
  orders: order[] = [];

  ngOnInit() {
    this.isAuth = this.authService.isAuthenticated();
    console.log('is authenticated ', this.isAuth);

    this.role = this.authService.getRole();
    console.log('role is ', this.role);

    console.log('token is ', this.authService.getToken());

    this.isAdmin = this.role === 'Admin';
  }

  onLogin() {
    this.authService.login();
  }

  onLogout() {       
    this.authService.logout();
  }

  getOrders() {
    this.orderService.getOrders().subscribe(
      data => {this.orders = data}
    );
  }

  getPrivacy() {
    this.orderService.getPrivacy().subscribe(
      data => {console.log(data)}
    );
  }
}
