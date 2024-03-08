import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from '../../../environments/env';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
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

  getAllEmployees(): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.hrUrl}/Employee`, {'headers': this.headers});
  }

  getEmployeeById(id: number): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.hrUrl}/Employee/${id}`, {'headers': this.headers});
  }

  postEmployee(employee: any): Observable<any> {
    return this.http.post<any>(`${env.baseUrl}/${env.hrUrl}/Employee`, employee, {'headers': this.headers});
  }

  putEmployee(employee: any): Observable<any> {
    return this.http.put<any>(`${env.baseUrl}/${env.hrUrl}/Employee`, employee, {'headers': this.headers});
  }

  deleteEmployee(id: number): Observable<any> {
    return this.http.delete<any>(`${env.baseUrl}/${env.hrUrl}/Employee/${id}`, {'headers': this.headers});
  }
}
