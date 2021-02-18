using System.Collections.Generic;

namespace RealEstateIdentity.ViewModels
{
    public class AgentOfferResponseViewModel
    {
        public int Response { get; set; }
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int PropertyId { get; set; }
        public virtual ICollection<AnswerViewModel> Answers { get; set; }
    }
}
