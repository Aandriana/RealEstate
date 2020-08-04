import {FeedbackList} from './feedback-list';

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

