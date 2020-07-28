import {ApiService} from './api.service';
import {accountUrl} from '../../configs/api-endpoint.constants';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {JwtResponseModel, UserProfile} from '../models';
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
    formData.append('FirstName', value.firstName);
    formData.append('LastName', value.lastName);
    formData.append('Image', value.image);
    formData.append('PhoneNumber', value.phoneNumber);
    formData.append('Email', value.email)
    return this.http.put(`${this.baseUrl}`, formData).pipe(map((response: JwtResponseModel) => {
      this.jwtService.addTokenToLS(response.token);
      if (!this.jwtService.checkToken()) {
        return false;
      }
      return true;
    }));
  }
}
