using System;
using System.Collections.Generic;

namespace RealEstate.BLL.DTO
{
    public class GetChatDto
    {
        public int Id { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GetMessageDto> Messages { get; set; }
        public int PagesCount { get; set; }
    }
}
