using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace RealEstate.DAL.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<AgentProperty> AgentProperties { get; set; }
    }
}
