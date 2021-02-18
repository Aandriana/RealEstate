using System.Collections.Generic;

namespace RealEstate.BLL.DTO
{
    public class OfferDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int PropertyId { get; set; }
        public int Status { get; set; }
        public string AgentProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public virtual ICollection<AnswerDto> Answers { get; set; }
    }
}
