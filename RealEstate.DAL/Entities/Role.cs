using Microsoft.AspNetCore.Identity;

namespace RealEstate.DAL.Entities
{
    public class Role : IdentityRole
    {
        public Role(string roleName) : base(roleName)
        {
        }
    }
}
