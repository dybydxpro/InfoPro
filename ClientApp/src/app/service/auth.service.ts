import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from '../../environments/env';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  headers: any = {};

  constructor(private http: HttpClient) {
    let token: any = "";
    if(localStorage.getItem('token')){
      token = localStorage.getItem('token');
    }
    this.headers = new HttpHeaders().append("content-type", "application/json").append("authenticate", `Bearer ${token}`);
  }

  login(credentials: any): Observable<any> {
    return this.http.post<any>(`${env.baseUrl}/${env.authUrl}/Auth/login`, credentials, {'headers': this.headers});
  }

  register(regData: any, role: string): Observable<any> {
    return this.http.post<any>(`${env.baseUrl}/${env.authUrl}/Auth/register/${role}`, regData, {'headers': this.headers});
  }

  reguser(user: any, role: string): Observable<any> {
    return this.http.post<any>(`${env.baseUrl}/${env.authUrl}/Auth/reguser/${role}`, user, {'headers': this.headers});
  }
}
