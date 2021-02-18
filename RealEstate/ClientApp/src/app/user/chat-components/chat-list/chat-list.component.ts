import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import {ChatService} from '../../../core/services/chat.service';
import {ChatListModel} from '../../../core/models';
import {Router} from '@angular/router';


@Component({
  selector: 'app-chat-list',
  templateUrl: './chat-list.component.html',
  styleUrls: ['./chat-list.component.scss']
})
export class ChatListComponent implements OnInit {

  chatList: ChatListModel[];
  today = new Date();
  constructor(private chatService: ChatService, private route: Router) { }

   ngOnInit(): void {
    this.getAllChats();
  }
  private getAllChats(): any{
    this.chatService.getAllChats().subscribe(data => this.chatList = data);
  }
  private getPhoto(imagePath: string): string {
    return 'http://localhost:52833/' + imagePath;
  }
  private isTodayMesssage(date: Date): boolean{
    this.today.setHours(0, 0, 0, 0);
    if (this.today < date) { return true; }
    return false;
  }
  public changeChat(id: number): any{
      this.route.navigateByUrl(`chat/${id}`);
     }
}
