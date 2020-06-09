using System.Collections.Generic;

namespace RealEstate.DAL.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public int Size { get; set;}
        public int Сategory { get; set; }
        public int FloorsNumber { get; set; }
        public int Price { get; set; }
        public string AgentId { get; set; }
        public virtual ICollection<AgentProperty> AgentsProperty { get;  set; }
    }
}
