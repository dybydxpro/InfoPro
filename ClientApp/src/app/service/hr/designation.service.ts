import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from '../../../environments/env';

@Injectable({
  providedIn: 'root'
})
export class DesignationService {
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

  getAllDesignations(): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.hrUrl}/Designation`, {'headers': this.headers});
  }

  getDesignationById(id: number): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.hrUrl}/Designation/${id}`, {'headers': this.headers});
  }

  postDesignation(designation: any): Observable<any> {
    return this.http.post<any>(`${env.baseUrl}/${env.hrUrl}/Designation`, designation, {'headers': this.headers});
  }

  putDesignation(designation: any): Observable<any> {
    return this.http.put<any>(`${env.baseUrl}/${env.hrUrl}/Designation`, designation, {'headers': this.headers});
  }

  deleteDesignation(id: number): Observable<any> {
    return this.http.delete<any>(`${env.baseUrl}/${env.hrUrl}/Designation/${id}`, {'headers': this.headers});
  }
}
