using System;

namespace RealEstateIdentity.ViewModels
{
    public class FeedBackViewModel
    {
        private int _rating;
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string AgentId { get; set; }
        public int Rating
        {
            get { return _rating; }
            set
            {
                if (value > 5 || value < 0) throw new InvalidOperationException();
                else _rating = value;
            }
        }
    }
}
