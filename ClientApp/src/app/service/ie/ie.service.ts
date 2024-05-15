import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from '../../../environments/env';

@Injectable({
  providedIn: 'root'
})
export class IeService {
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

  getAllProductionFloors(): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.ieUrl}/ProductionFloor`, {'headers': this.headers});
  }

  getProductionFloorById(id: number): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.ieUrl}/ProductionFloor/${id}`, {'headers': this.headers});
  }

  postProductionFloor(department: any): Observable<any> {
    return this.http.post<any>(`${env.baseUrl}/${env.ieUrl}/ProductionFloor`, department, {'headers': this.headers});
  }

  putProductionFloor(department: any): Observable<any> {
    return this.http.put<any>(`${env.baseUrl}/${env.ieUrl}/ProductionFloor`, department, {'headers': this.headers});
  }

  deleteProductionFloor(id: number): Observable<any> {
    return this.http.delete<any>(`${env.baseUrl}/${env.ieUrl}/ProductionFloor/${id}`, {'headers': this.headers});
  }
}
