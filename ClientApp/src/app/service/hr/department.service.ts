import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from '../../../environments/env';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  headers: any = {};

  constructor(private http: HttpClient) {
    let token: any = "";
    if(localStorage.getItem('token')){
      token = localStorage.getItem('token');
    }
    this.headers = new HttpHeaders().append("content-type", "application/json").append("authenticate", `Bearer ${token}`);
  }

  getAllDepartments(): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.hrUrl}/Department`, {'headers': this.headers});
  }

  getDepartmentById(id: number): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.hrUrl}/Department/${id}`, {'headers': this.headers});
  }

  postDepartment(department: any): Observable<any> {
    return this.http.post<any>(`${env.baseUrl}/${env.hrUrl}/Department`, department, {'headers': this.headers});
  }

  putDepartment(department: any): Observable<any> {
    return this.http.put<any>(`${env.baseUrl}/${env.hrUrl}/Department`, department, {'headers': this.headers});
  }

  deleteDepartment(id: number): Observable<any> {
    return this.http.delete<any>(`${env.baseUrl}/${env.hrUrl}/Department/${id}`, {'headers': this.headers});
  }
}
