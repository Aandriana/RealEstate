using RealEstate.DAL.Entities;
using System.Collections.Generic;

namespace RealEstate.DAL.Entities
{
    public class Chat: BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<ChatUser> Participants { get; set; }

        public Chat()
        {
            Messages = new List<Message>();
        }
    }
}
