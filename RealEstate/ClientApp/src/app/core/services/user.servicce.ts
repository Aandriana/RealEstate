import {ApiService} from './api.service';
import {accountUrl} from '../../configs/api-endpoint.constants';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {AgentById, JwtResponseModel, UserProfile} from '../models';
import {map} from 'rxjs/operators';
import {JwtService} from './jwt.service';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly baseUrl = accountUrl;

  constructor(
    private http: ApiService,
    private jwtService: JwtService
  ) {}

  getMyProfile(): Observable<UserProfile>{
    return this.http.get(`${this.baseUrl}`);
  }
  editMyProfile(value): Observable<boolean>{
    const formData = new FormData();
    for (const user in value)
    {
      formData.append(user, value[user]);
    }
    return this.http.put(`${this.baseUrl}`, formData).pipe(map((response: JwtResponseModel) => {
      this.jwtService.addTokenToLS(response.token);
      return this.jwtService.checkToken();
    }));
  }
  getAgentById(id): Observable<AgentById> {
    return this.http.get(`${this.baseUrl}/agent/${id}`);
  }
}
