import {propertyUrl} from '../../configs/api-endpoint.constants';
import {ApiService} from './api.service';
import {Injectable} from '@angular/core';
import {HttpParams} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  readonly baseUrl = propertyUrl;

  constructor(
    private http: ApiService
  ) {}

  getProperties(pageNumber, pageSize): any {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    return this.http.get(`${this.baseUrl}/user`, params);
  }
}
