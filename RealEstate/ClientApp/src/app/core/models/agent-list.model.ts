export interface AgentListModel {
  id: string;
  firstName: string;
  lastName: string;
  imagePath: string;
  agentProfile: AgentProfile;
}

export interface AgentProfile {
  city: string;
  defaultRate: number;
  rating: number;
}
