import { Injectable } from '@angular/core';
import {ApiService} from './api.service';
import {offerUrl} from '../../configs/api-endpoint.constants';
import {Observable} from 'rxjs';
import {HttpParams} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OfferService {
  readonly baseUrl = offerUrl;
  constructor(private http: ApiService) { }
  sendOfferAsUser(offer): Observable<any>{
    return this.http.post(`${this.baseUrl}`, offer);
  }
  sendOfferAsAgent(offer, array): Observable<any>{
    const form = new FormData();
    for (const value in offer) {
      form.append(value, offer[value]);
    }
    form.delete('answers');
    for (let i = 0; i < array.length; i++) {
      form.append(`Answers[${i}][Question]`, array[i].question);
      form.append(`Answers[${i}][AnswerText]`, array[i].answerText);
    }
    return this.http.post(`${this.baseUrl}/agent`, form);
  }
  getOffersForAgetn(pageNumber, pageSize, status): any{
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber);
    params = params.append('pageSize', pageSize);
    if (status !== null){
      params = params.append('offerStatus', status);
    }
    return this.http.getWithParams(`${this.baseUrl}`, params);
  }
  acceptAgentResponse(id, offer, array): Observable<any>{
    const form = new FormData();
    for (const value in offer) {
      form.append(value, offer[value]);
    }
    form.delete('answers');
    for (let i = 0; i < array.length; i++) {
      form.append(`Answers[${i}][Question]`, array[i].question);
      form.append(`Answers[${i}][AnswerText]`, array[i].answerText);
    }
    return this.http.put(`${this.baseUrl}/agent/${id}`, form);
  }
  responseFromUser(id, data): Observable<any>{
    return this.http.put(`${this.baseUrl}/${id}`, data);
  }
  getPropertyId(id): Observable<any>{
    return this.http.get(`${this.baseUrl}/${id}/property`);
  }
  agentResponse(id, data): Observable<any>{
    const form = new FormData();
    form.append(`response`, data.response.value);
    return this.http.put(`${this.baseUrl}/agent/${id}`, form);
  }
}
