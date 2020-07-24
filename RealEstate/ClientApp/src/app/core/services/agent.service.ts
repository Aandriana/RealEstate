import {ApiService} from './api.service';
import {accountUrl} from '../../configs/api-endpoint.constants';
import {Injectable} from '@angular/core';
import {HttpParams} from '@angular/common/http';
import {AgentListModel} from '../models';
import {Observable} from 'rxjs';
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
}
