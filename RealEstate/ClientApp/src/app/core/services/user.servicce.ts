import {ApiService} from './api.service';
import {accountUrl} from '../../configs/api-endpoint.constants';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {UserProfile} from '../models';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly baseUrl = accountUrl;

  constructor(
    private http: ApiService
  ) {}

  getMyProfile(): Observable<UserProfile>{
    return this.http.get(`${this.baseUrl}`);
  }
}
