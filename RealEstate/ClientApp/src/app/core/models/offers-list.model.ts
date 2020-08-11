export interface OffersListModel {
  id: number;
  comment: string;
  rate: number;
  status: number;
  agentProfileId: string;
  image: string;
  firstName: string;
  lastName: string;
  answers: Answers[];
}
export interface Answers {
  answerText: string;
  question: string;
}
