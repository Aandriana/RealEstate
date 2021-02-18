using RealEstate.DAL.Entities;
using System;

namespace RealEstate.DAL.Entities
{
    public class Message: BaseEntity
    {
        public string Text { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
