using System;
using System.Collections.Generic;

namespace RealEstate.DAL.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public UserProfile SenderProfile { get; set; }
        public UserProfile ReceiverProfile { get; set;}
    }

}
