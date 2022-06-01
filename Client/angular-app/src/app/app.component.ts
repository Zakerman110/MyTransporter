import { Component } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { OrderService } from './core/services/order.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public oidcSecurityService: OidcSecurityService, 
              public http: HttpClient, 
              public orderService: OrderService) {}

  isAuth: boolean = false;
  isAdmin: boolean = false;
  role: string = '';
  username: string = '';
  // @ts-ignore
  userData$: Observable<any>;

  ngOnInit() {
    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData, accessToken, idToken }) => {
      this.isAuth = isAuthenticated;
      console.log('is authenticated', this.isAuth);
      console.log("userdata is", userData);
      this.role = userData.role;
      this.username = userData.username;
      console.log('you role is', this.role);
      this.isAdmin = this.role === 'Admin';
    });
  }

  onLogin() {
    this.oidcSecurityService.authorize();
  }

  onLogout() {       
    this.oidcSecurityService.logoff();
  }

  getPrivacy() {
    this.orderService.getPrivacy().subscribe(
      data => {console.log(data)}
    );
  }
}
