export interface ChatModel {
  id: number;
  createdDateUtc: Date;
  name: string;
  pagesCount: number;
  messages: Messages[];
}
export interface Messages {
  createdDateUtc: Date;
   createdById: string;
   firstName: string;
   lastName: string;
   imagePath: string;
   text: string;
   chatId: number;
}
