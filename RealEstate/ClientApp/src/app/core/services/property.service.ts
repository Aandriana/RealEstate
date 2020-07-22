import {propertyUrl} from '../../configs/api-endpoint.constants';
import {ApiService} from './api.service';
import {Injectable} from '@angular/core';
import {HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {JwtResponseModel, PropertyListModel} from '../models';
import {FileInput} from 'ngx-material-file-input';
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
    return this.http.get(`${this.baseUrl}/user`, params);
  }
  firstStep(addPropertyForm): void{
    this.propertyForm.append('Size', addPropertyForm.size);
    this.propertyForm.append('Category', addPropertyForm.category);
    this.propertyForm.append('FloorsNumber', addPropertyForm.floorsNumber);
    this.propertyForm.append('Floors', addPropertyForm.floors);
    this.propertyForm.append('Price', addPropertyForm.price);
  }
  secondStep(addPropertyForm): void{
      this.propertyForm.append('City', addPropertyForm.city);
      this.propertyForm.append('Address', addPropertyForm.address);
      this.propertyForm.append('BuildYear', addPropertyForm.buildYear);
    }
  thirtStep(length, questionsArray): void {
    for (let i = 0; i < length; i++) {
      this.propertyForm.append(`Questions[${i}][QuestionText]`, questionsArray.at(i).value);
    }
}
  addProperty(addPropertyForm): Observable<boolean> {
    const cont_imgs: FileInput = addPropertyForm.photos.value;
    let files: File[] = []
    if (cont_imgs){
      files = cont_imgs.files;
    }
    if (files.length > 0) {
      for (let i = 0; i < files.length; i++) {
        this.propertyForm.append('contentImages', files[i]);
      }
    }
    return this.http.post(`${this.baseUrl}`, this.propertyForm).pipe(map((response: JwtResponseModel)  => {
      return true;
    }));
  }
}
