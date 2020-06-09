using System.Collections.Generic;

namespace RealEstate.DAL.Entities
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public User User { get; set; }
        public Feedback IWroteFeedback { get;  set; }
        public Feedback FeedbackForMe { get; set; }
    }
}
