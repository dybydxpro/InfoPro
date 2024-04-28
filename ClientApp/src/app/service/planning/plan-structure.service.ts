import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from '../../../environments/env';

@Injectable({
  providedIn: 'root'
})
export class PlanStructureService {
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

  getAllPlanStructures(): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.planningUrl}/PlanStruct`, {'headers': this.headers});
  }

  getPlanStructureById(id: number): Observable<any> {
    return this.http.get<any>(`${env.baseUrl}/${env.planningUrl}/PlanStruct/${id}`, {'headers': this.headers});
  }

  postPlanStructure(data: any){
    return this.http.post<any>(`${env.baseUrl}/${env.planningUrl}/PlanStruct`, data, {'headers': this.headers});
  }

  putPlanStructure(data: any){
    return this.http.put<any>(`${env.baseUrl}/${env.planningUrl}/PlanStruct`, data, {'headers': this.headers});
  }

  deletePlanStructure(id: number){
    return this.http.delete<any>(`${env.baseUrl}/${env.planningUrl}/PlanStruct/${id}`, {'headers': this.headers});
  }
}
