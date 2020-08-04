using System.Collections.Generic;

namespace RealEstate.DAL.Entities
{
    public class Property : BaseEntity
    {
        public double Size { get; set; }
        public int Category { get; set; }
        public int FloorsNumber { get; set; }
        public int Floors { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int BuildYear { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<PropertyPhoto> Photos { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

    }
}
