export interface PropertyByIdModel {
  id: number;
  size: number;
  category: number;
  floorsNumber: number;
  floors: number;
  price: number;
  city: string;
  address: string;
  buildYear: number;
  image: string;
  status: number;
  offers: Offers[];
  photos: Photos[];
  questions: Questions[];
}
export interface Offers {
id: number;
comment: string;
rate: number;
status: number;
agentProfileId: string;
image: string;
firstName: string;
lastName: string;
}
export interface Photos {
  photos: string[];
}
export interface Questions{
  questionText: string;
}
