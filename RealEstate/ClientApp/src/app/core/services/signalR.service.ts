import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:52833/chatHub', {accessTokenFactory(): string | Promise<string> {
          return localStorage.getItem('jwt');
        }})
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public addTransferChartDataListener = (next) => {
    this.hubConnection.on('ReceiveMessage', (data) => {
      next(data);
    });
  }
}
