namespace RealEstate.BLL.DTO
{
    public class UsersListDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public AgentsListDto AgentProfile { get; set; }
    }
}
