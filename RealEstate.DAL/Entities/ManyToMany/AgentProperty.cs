namespace RealEstate.DAL.Entities
{
    public class AgentProperty
    {
        public string AgentId {get; set;}
        public User Agent { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
