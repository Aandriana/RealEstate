using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.BLL.DTO
{
    public class FeedBackDto
    {
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string AgentId { get; set; }
        public int Rating { get; set; }
    }
}
