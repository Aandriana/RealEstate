import {Component, ElementRef, EventEmitter, Input, OnChanges, OnDestroy, OnInit, Output, ViewChild} from '@angular/core';
import {AgentById, ChatModel, Message, Messages, PaginationParams} from '../../../core/models';
import {ChatService} from '../../../core/services/chat.service';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {JwtService} from '../../../core/services/jwt.service';
import {SignalRService} from '../../../core/services/signalR.service';
import {ActivatedRoute, Router} from '@angular/router';
import {filterToMembersWithDecorator} from '@angular/compiler-cli/src/ngtsc/reflection';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  @ViewChild('chatScroller', {static: false}) scroll: ElementRef;

  currentChat: ChatModel;
  currentUserId: string;
  disableScrollDown = false;
  form: FormGroup;
  pageNumber = 1;
  pageSize = 10;
  newMessage: Messages;

  constructor(private chatService: ChatService, private jwtService: JwtService, public signalRService: SignalRService,
              private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): any {
    this.newMessage =  {} as Messages;
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataListener((message) => {
      this.mapMessage(message);
      this.currentChat.messages.push(this.newMessage);
    });
    this.form = new FormGroup({
      text: new FormControl(null, [Validators.required, Validators.maxLength(256)]),
    });
    this.currentUserId = this.jwtService.getCurrentUserId();
    this.route.params.subscribe(value => {
      if (value.id) {
        const paginationParams: PaginationParams = {pageNumber: this.pageNumber, pageSize: this.pageSize};
        this.chatService.getChatById(value.id, paginationParams).subscribe((data: ChatModel) => {
          this.currentChat = data;
          console.log(this.currentChat);
        });
      }
    });
  }
  private getPhoto(imagePath: string): string {
    return 'http://localhost:52833/' + imagePath;
  }
  // ngAfterViewChecked(): void {
  //   if (this.currentChat) {
  //     this.scrollToBottom();
  //   }
  // }
  // public updateChat(chatId: number): any{
  //   const paginationParams: PaginationParams = { pageNumber: this.pageNumber, pageSize: this.pageSize };
  //   this.chatService.getChatById(this.currentChat.id, paginationParams).subscribe(async (data: ChatModel) => {
  //       this.currentChat.messages.unshift(...data.messages.reverse());
  //       this.pageNumber++;
  //     });
  // }
  private mapMessage(message: any): void{
    this.newMessage.createdById = message.posterId;
    this.newMessage.createdDateUtc = message.timestamps;
    this.newMessage.firstName =  message.posterFirstName;
    this.newMessage.lastName = message.posterLastName;
    this.newMessage.imagePath = message.posterLastPhoto;
    this.newMessage.text = message.text;
    this.newMessage.chatId = this.currentChat.id;
  }
  private sendMessage(): any{
    const message: Message = {
      text: this.form.value.text,
      chatId: this.currentChat.id,
    };
    this.chatService.addMessage(message).subscribe(async (msg: string) => {
      this.form.reset();
    });
  }
  // private reset(): void{
  //   this.pageNumber = 1;
  // }
  //  onScroll(): any{
  //   const element = this.scroll.nativeElement;
  //   const atBottom = element.scrollHeight - element.scrollTop === element.clientHeight;
  //   if (this.disableScrollDown && atBottom) {
  //     this.disableScrollDown = false;
  //   }
  //   if (element.scrollTop === 0 && this.pageNumber <= this.currentChat.pagesCount) {
  //     this.loadMessages();
  //     element.scrollTop = 35;
  //   }
  //
  //   else {
  //     this.disableScrollDown = true;
  //   }
  // }
  // private scrollToBottom(): void {
  //   if (this.disableScrollDown) {
  //     return;
  //   }
  //   try {
  //     this.scroll.nativeElement.scrollTop = this.scroll.nativeElement.scrollHeight;
  //   } catch (err) { }
  // }
  // private loadMessages(): any{
  //   const paginationParams: PaginationParams = { pageNumber: this.pageNumber, pageSize: this.pageSize };
  //   this.chatService.getChatById(this.currentChat.id, paginationParams)
  //     .subscribe(async (data: ChatModel) => {
  //       this.currentChat.messages.unshift(...data.messages.reverse());
  //       this.pageNumber++;
  //     });
  // }
}
