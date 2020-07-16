import {propertyUrl} from '../../configs/api-endpoint.constants';
import {ApiService} from './api.service';
import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  readonly baseUrl = propertyUrl;

  constructor(
    private http: ApiService
  ) {}

  getProperties(): any {
    return this.http.get(`${this.baseUrl}/user`);
  }
}
