using System;

namespace RealEstateIdentity.ViewModels
{
    public class FeedBackListViewModel
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
    }
}
