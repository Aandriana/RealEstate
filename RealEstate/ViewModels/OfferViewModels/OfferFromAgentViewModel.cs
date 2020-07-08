using System.Collections.Generic;

namespace RealEstateIdentity.ViewModels
{
    public class OfferFromAgentViewModel
    {
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int PropertyId { get; set; }
        public virtual ICollection<AnswerViewModel> Answers { get; set; }
    }
}
