export interface AgentById {
  firstName: string;
  lastName: string;
  phoneNumber: string;
  email: string;
  imagePath: string;
  city: string;
  defaultRate: number;
  rating: number;
  birthDate: Date;
  description: string;
  successSales: number;
  failedSales: number;
  feedBacks: FeedbackList[];
}
export interface FeedbackList {
  userId: string;
  comment: string;
  date: Date;
  rating: number;
  firstName: string;
  lastName: string;
  imagePath: string;
}
