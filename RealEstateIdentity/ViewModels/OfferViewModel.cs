using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateIdentity.ViewModels
{
    public class OfferViewModel
    {
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int PropertyId { get; set; }
        public int Status { get; set; }
        public virtual ICollection<AnswerViewModel> Answers { get; set; }
    }
}
