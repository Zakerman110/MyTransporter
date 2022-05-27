import { Component } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public oidcSecurityService: OidcSecurityService, public http: HttpClient) {}

  isAuth: boolean = false;

  ngOnInit() {
    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData, accessToken, idToken }) => {
      console.log('is authenticated', isAuthenticated)
      this.isAuth = isAuthenticated;
    });
  }

  login() {
    this.oidcSecurityService.authorize();
  }

  logout() {
    this.oidcSecurityService.logoff();
  }

  callApi() {
    const token = this.oidcSecurityService.getAccessToken().subscribe((token) => {
      console.log(token);
      const httpOptions = {
        headers: new HttpHeaders({
          Authorization: 'Bearer ' + token,
        }),
      };
      this.http.get("https://localhost:7192/gateway/order", httpOptions)
      //this.http.get("https://localhost:7239/api/order", httpOptions)
        .subscribe((data: any) => {
          console.log("api result: ", data);
        });
    });

  }
}
