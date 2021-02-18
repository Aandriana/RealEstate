using System;

namespace RealEstate.BLL.DTO
{
    public class AddMessageDto
    {
        public string CreatedById { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string Text { get; set; }
        public int ChatId { get; set; }
    }
}
