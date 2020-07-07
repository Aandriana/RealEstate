using System;

namespace RealEstate.DAL.Entities
{
    public class Feedback : BaseEntity
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string AgentId { get; set; }
        public User User { get; set; }
        public AgentProfile Agent { get; set; }
        public int Rating { get; set; }
    }
}
