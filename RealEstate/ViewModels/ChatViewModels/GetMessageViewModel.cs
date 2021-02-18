using System;

namespace RealEstate.ViewModels
{
    public class GetMessageViewModel
    {
        public DateTime CreatedDateUtc { get; set; }
        public string CreatedById { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public string Text { get; set; }
        public int ChatId { get; set; }
    }
}
