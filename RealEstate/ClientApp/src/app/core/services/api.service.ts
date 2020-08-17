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

  getWithParams(url, params): any{
    return this.http.get(url, {params});
  }
  get(url): any{
    return this.http.get(url);
  }
  put(url, data): any {
    return this.http.put(url, data);
  }
  patch(url): any{
    return this.http.patch(url, null);
  }
  delete(url): any{
    return this.http.delete(url);
  }
}
