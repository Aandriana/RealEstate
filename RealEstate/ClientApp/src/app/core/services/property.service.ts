import {propertyUrl} from '../../configs/api-endpoint.constants';
import {ApiService} from './api.service';
import {Injectable} from '@angular/core';
import {HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {GetQuestionModel, OffersListModel, PropertyByIdModel, PropertyListModel} from '../models';
import {FileInput} from 'ngx-material-file-input';

@Injectable({
  providedIn: 'root'
})
export class  PropertyService {
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
  editProperty(id, updatePropertyForm): Observable<any> {
   const form = new FormData();
    for (const property in updatePropertyForm) {
      form.append(property, updatePropertyForm[property]);
    }
   return this.http.put(`${this.baseUrl}/${id}`, form);
  }
  getPhotos(id): Observable<string[]>{
    return this.http.get(`${this.baseUrl}/${id}/photos`);
  }
  editPhotos(id, editPhotosForm, photos): Observable<any>{
    const form = new FormData();
    const images: FileInput = editPhotosForm.get('addedContentImages').value;
    let files: File[] = [];
    if (images) {
      files = images.files;
    }
    for (let i = 0; i < files.length; i++) {
      form.append(`addedContentImages`, files[i]);
    }
    for (let i = 0; i < photos.length; i++) {
      form.append(`notDeletedContentImageUrls[${i}]`, photos[i]);
    }
    return this.http.put(`${this.baseUrl}/photos/${id}`, form);
  }
  deleteProperty(id): Observable<any>{
    return this.http.patch(`${this.baseUrl}/${id}/delete`);
  }
  restoreProperty(id): Observable<any>{
    return this.http.patch(`${this.baseUrl}/${id}/restore`);
  }
  getOffersToProperty(id, pageNumber, pageSize, status): Observable<OffersListModel[]> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    if (status !== null){
      params = params.append('offerStatus', status);
    }
    return this.http.getWithParams(`${this.baseUrl}/${id}/offers`, params);
  }
  getQuestions(id): Observable<GetQuestionModel[]> {
    return this.http.get(`${this.baseUrl}/${id}/questions`);
  }
  updateQuestion(id, questionUpdateForm): Observable<any>{
    return this.http.put(`${this.baseUrl}/question/${id}`, questionUpdateForm);
  }
  deleteQuestion(id): Observable<any> {
    return this.http.delete(`${this.baseUrl}/question/${id}`);
  }
  addQuestion(propertyId, addQuestionForm): Observable<any> {
    return this.http.post(`${this.baseUrl}/${propertyId}/questions`, addQuestionForm);
  }
  getPropertiesforAgent(pageNumber, pageSize): Observable<PropertyListModel[]> {
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    return this.http.getWithParams(`${this.baseUrl}/agent`, params);
  }
  getPropertyForAgent(id): Observable<PropertyByIdModel> {
  return this.http.get(`${this.baseUrl}/agent/${id}`);
  }
}
