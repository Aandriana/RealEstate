import {propertyUrl} from '../../configs/api-endpoint.constants';
import {ApiService} from './api.service';
import {Injectable} from '@angular/core';
import {HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {JwtResponseModel, PropertyListModel} from '../models';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  readonly baseUrl = propertyUrl;
  propertyForm = new FormData();
  constructor(
    private http: ApiService
  ) {}
  getProperties(pageNumber, pageSize): Observable<PropertyListModel[]> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    return this.http.getWithParams(`${this.baseUrl}/user`, params);
  }
  firstStep(addPropertyForm, category): void{
    this.propertyForm = new FormData();
    this.propertyForm.append('Size', addPropertyForm.size);
    this.propertyForm.append('Сategory', category);
    this.propertyForm.append('FloorsNumber', addPropertyForm.floorsNumber);
    this.propertyForm.append('Floors', addPropertyForm.floors);
    this.propertyForm.append('Price', addPropertyForm.price);
  }
  secondStep(addPropertyForm): void{
    this.propertyForm.append('City', addPropertyForm.city);
    this.propertyForm.append('Address', addPropertyForm.address);
    this.propertyForm.append('BuildYear', addPropertyForm.buildYear);
    }
  thirdStep(length, questionsArray): void {
    for (let i = 0; i < length; i++) {
      this.propertyForm.append(`Questions[${i}][QuestionText]`, questionsArray.at(i).value);
    }
  }
  addProperty(length, agentsArray): Observable<any> {
    for (let i = 0; i < length; i++) {
      this.propertyForm.append(`AgentsId[${i}]`, agentsArray.at(i).value);
    }
    return  this.http.post(`${this.baseUrl}`, this.propertyForm);
  }
  fourthStep(files): any {
    if (files.length > 0) {
      for (let i = 0; i < files.length; i++) {
        this.propertyForm.append('Photos', files[i]);
      }
    }
  }
}
