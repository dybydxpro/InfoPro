import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from '../../../environments/env';

@Injectable({
  providedIn: 'root'
})
export class FileGenService {
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

  handleSpredsheets(data: any): Observable<any> {
    return this.http.post<any>(`${env.baseUrl}/${env.planningUrl}/FileGen/planGen`, data, {'headers': this.headers});
  }
}
