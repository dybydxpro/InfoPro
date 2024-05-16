import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { env } from '../../environments/env';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  headers: any = {};

  constructor(private http: HttpClient) {
    let token: any = "";
    if(typeof localStorage !== 'undefined' && localStorage.getItem('token') !== 'undefined'){
      token = localStorage.getItem('token');
    }
    this.headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
  }

  userDetails(): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.authUrl}/User/userDetails`, {'headers': this.headers});
  }

  userDetailsByToken(token: any): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.authUrl}/User/userDetails`, {'headers': new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })});
  }
}
