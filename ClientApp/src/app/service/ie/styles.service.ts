import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from '../../../environments/env';

@Injectable({
  providedIn: 'root'
})
export class StylesService {
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

  getAllStyles(): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.ieUrl}/Style`, {'headers': this.headers});
  }

  getStyleById(id: number): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.ieUrl}/Style/${id}`, {'headers': this.headers});
  }

  postStyle(department: any): Observable<any> {
    return this.http.post<any>(`${env.baseUrl}/${env.ieUrl}/Style`, department, {'headers': this.headers});
  }

  putStyle(department: any): Observable<any> {
    return this.http.put<any>(`${env.baseUrl}/${env.ieUrl}/Style`, department, {'headers': this.headers});
  }

  deleteStyle(id: number): Observable<any> {
    return this.http.delete<any>(`${env.baseUrl}/${env.ieUrl}/Style/${id}`, {'headers': this.headers});
  }
}
