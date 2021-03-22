import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Constant, HandleLocalStore } from './handleLocalSore';

@Injectable({
  providedIn: 'root'
})
export class AuthSevice {
  public Token: string;
  jwtHelper = new JwtHelperService();


  constructor(private route: Router, protected http: HttpClient) { }
  login(phoneNumber: string, password: string, clientId: string, clientSecret: string): Observable<any> {
    return this.http.post(`${environment.apiUrl.accountUrl}api/v1/sign-in/password`, {
      phoneNumber,
      password,
      clientId: environment.clientInfo.clientId,
      clientSecret: environment.clientInfo.clientSecret
    }).pipe(map(user => {
        if (user){
          localStorage.setItem('currentuser', JSON.stringify(user));
          HandleLocalStore.writeaccessToken(user[`accessToken`]);
          HandleLocalStore.writerefreshToken(user[`refreshToken`]);
        }
        else{
          this.logOut();
        }
        return user;
    }));
  }

  logOut(): void{
    localStorage.removeItem(Constant.LOCALVARIABLENAME.accessToken);
    localStorage.removeItem(Constant.LOCALVARIABLENAME.refreshToken);
    localStorage.removeItem('currentuser');
  }
  loginIn(): boolean{
    const token = HandleLocalStore.getToken();
    return token &&
     !this.jwtHelper.isTokenExpired(token);
  }
  sentOtp(phoneNumber: string): Observable<any>{
    return this.http.post(`${environment.apiUrl.accountUrl}api/v1/sign-up/send-otpsms`, {
      phoneNumber
    }).pipe(map(res => {
      return res;
    }));
  }
  verifyOtp(phoneNumber: string, otpcode: string): Observable<any>{
      return this.http.post(`${environment.apiUrl.accountUrl}api/v1/sign-up/verify-otpsms`, {
        phoneNumber,
        otpcode
      }).pipe(map(res => {
         localStorage.setItem('smstoken', res[`smsOtpToken`]);
         return res;
      }));
  }
  signUp(name: string, email: string, password: string,
         phoneNumber: string, smsOtpToken: string, otpCode: string, clientId: string): Observable<any>{
    return this.http.post(`${environment.apiUrl.accountUrl}api/v1/sign-up`, {
      name,
      email,
      password,
      phoneNumber,
      smsOtpToken,
      otpCode,
      clientId
    }).pipe(map(res => {
      return res;
    }));
  }
}
