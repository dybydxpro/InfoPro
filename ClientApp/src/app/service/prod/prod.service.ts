import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from '../../../environments/env';

@Injectable({
  providedIn: 'root'
})
export class ProdService {
  headers: any = {};

  constructor(private http: HttpClient) {
    let token: any = "";
    if(typeof localStorage !== 'undefined' && localStorage.getItem('token') !== 'undefined'){
      token = localStorage.getItem('token');
    }
    this.headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
  }

  handleForecast(): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.prodUrl}/Forecast`, {'headers': this.headers});
  }
}
