import { Injectable } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private token: string = ''
  private isAuth: boolean = false;

  constructor(public oidcSecurityService: OidcSecurityService,
              private http: HttpClient) { }

  login() {
    this.oidcSecurityService.authorize();
  }

  logout() {
    this.oidcSecurityService.logoff();
  }

  public getToken(): string {
    const token = this.oidcSecurityService.getAccessToken().subscribe((token) => {
        this.token = token;
    })
    return this.token ? this.token : ''
  }

  public isAuthenticated(): boolean {
    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData, accessToken, idToken }) => {
        this.isAuth = isAuthenticated;
      });
    if (this.isAuth) {
      return true
    } else return false
  }

}
