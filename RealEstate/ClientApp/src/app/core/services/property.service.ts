import {propertyUrl} from '../../configs/api-endpoint.constants';
import {ApiService} from './api.service';
import {Injectable} from '@angular/core';
import {HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {PropertyByIdModel, PropertyListModel} from '../models';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  readonly baseUrl = propertyUrl;
  propertyForm = new FormData();
  constructor(
    private http: ApiService
  ) {}
  getProperties(pageNumber, pageSize, category, status): Observable<PropertyListModel[]> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    if (category !== null) {
      params = params.append('Category', category);
    }
    if (status !== null){
      params = params.append('Status', status);
    }
    return this.http.getWithParams(`${this.baseUrl}/user`, params);
  }

  firstStep(addPropertyForm): void{
    this.propertyForm = new FormData();
    for(const property in addPropertyForm) {
      this.propertyForm.append(property, addPropertyForm[property]);
    }
  }
  secondStep(addPropertyForm): void{
    for(const property in addPropertyForm) {
      this.propertyForm.append(property, addPropertyForm[property]);
    }
    }
  thirdStep(length, questionsArray): void {
    for (let i = 0; i < length; i++) {
      this.propertyForm.append(`Questions[${i}][QuestionText]`, questionsArray.at(i).value);
    }
  }
  fourthStep(files): any {
    if (files.length > 0) {
      for (let i = 0; i < files.length; i++) {
        this.propertyForm.append('Photos', files[i]);
      }
    }
  }
  addProperty(length, agentsArray): Observable<any> {
    for (let i = 0; i < length; i++) {
      this.propertyForm.append(`AgentsId[${i}]`, agentsArray.at(i).value);
    }
    return  this.http.post(`${this.baseUrl}`, this.propertyForm);
  }
  getPropertyById(Id): Observable<PropertyByIdModel>{
    return this.http.get(`${this.baseUrl}/${Id}`);
  }
}
