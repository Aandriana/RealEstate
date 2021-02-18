import { Injectable } from '@angular/core';
import {chatUrl} from '../../configs/api-endpoint.constants';
import {ApiService} from './api.service';
import {Observable} from 'rxjs';
import {ChatListModel, ChatModel, PaginationParams} from '../models';
import {HttpParams} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  readonly baseUrl = chatUrl;
  constructor(private http: ApiService) { }
  createNewChat(chat): Observable<any>{
    return this.http.post(`${this.baseUrl}`, chat);
  }
  addMessage(message): Observable<any>{
    const form = new FormData();
    for (const value in message) {
      form.append(value, message[value]);
    }
    return this.http.post(`${this.baseUrl}/message`, message);
  }
  getChatById(Id, paginationParams: PaginationParams): Observable<ChatModel>{
    let params = new HttpParams();
    params = params.append('pageNumber', paginationParams.pageNumber.toString());
    params = params.append('pageSize', paginationParams.pageSize.toString());
    return this.http.getWithParams(`${this.baseUrl}/${Id}`, params);
  }
  getAllChats(): Observable<ChatListModel[]>{
    return this.http.get(`${this.baseUrl}`);
  }
}
