using System;
using System.Collections.Generic;

namespace RealEstate.DAL.Entities
{
    public class AgentProfile
    {
        public string Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public double DefaultRate { get; set; }
        public int SuccessSales { get; set; }
        public int FailedSales { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public double Rating { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
