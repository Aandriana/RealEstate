using System.Collections.Generic;

namespace RealEstateIdentity.ViewModels
{
    public class GetAgentByIdInfoViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public double DefaultRate { get; set; }
        public int SuccessSales { get; set; }
        public int FailedSales { get; set; }
        public double Rating { get; set; }
        public virtual ICollection<FeedBackListViewModel> FeedBacks { get; set; }
    }
}
