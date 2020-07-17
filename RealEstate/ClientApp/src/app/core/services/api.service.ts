import {HttpClient, HttpParams} from '@angular/common/http';
import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient) {
  }

  post(url, postData): any {
    return this.http.post(url, postData);
  }

  get(url, params): any{
    return this.http.get(url, {params});
  }


}