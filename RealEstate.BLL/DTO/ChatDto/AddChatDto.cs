using System;
using System.Collections.Generic;

namespace RealEstate.BLL.DTO
{
    public class AddChatDto
    {
        public string Name { get; set; }
        public string ParticipantId { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string CreatedById { get; set; }
    }
}
