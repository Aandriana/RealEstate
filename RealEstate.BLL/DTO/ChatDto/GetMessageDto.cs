using System;

namespace RealEstate.BLL.DTO
{
    public class GetMessageDto
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
