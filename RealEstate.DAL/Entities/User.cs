using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RealEstate.DAL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public AgentProfile AgentPrifile { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
