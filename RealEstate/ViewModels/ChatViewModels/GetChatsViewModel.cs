using System;

namespace RealEstate.ViewModels
{
    public class GetChatsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public string UserId { get; set; }
        public string LastMessage { get; set; }
        public int ChatId { get; set; }
        public DateTime CreatedDateUtc { get; set; }
    }
}
