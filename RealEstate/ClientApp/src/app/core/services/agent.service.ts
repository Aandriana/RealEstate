import {ApiService} from './api.service';
import {accountUrl} from '../../configs/api-endpoint.constants';
import {Injectable} from '@angular/core';
import {HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {AgentById, AgentListModel} from '../models';
@Injectable({
  providedIn: 'root'
})
export class AgentService {
  readonly baseUrl = accountUrl;

  constructor(
    private http: ApiService
  ) {}

  getAgents(pageNumber, pageSize): Observable<AgentListModel[]>{
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    return this.http.getWithParams(`${this.baseUrl}/agents`, params);
  }
  getMyProfile(): Observable<AgentById>{
    return this.http.get(`${this.baseUrl}/agent`);
  }
  editMyProfile(agent, user): any{
    const formData = new FormData();
    for (const item in user)
    {
      formData.append(item, user[item]);
    }
    for (const  value in agent)
    {
      formData.append(`agentProfile[${value}]`, agent[value]);
    }
    return this.http.put(`${this.baseUrl}/agent`, formData);
  }
}
