using System.Collections.Generic;

namespace RealEstate.DAL.Entities
{
    public class Offer : BaseEntity
    {
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int PropertyId { get; set; }
        public int Status { get; set; }
        public string AgentProfileId { get; set; }
        public Property Property { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
