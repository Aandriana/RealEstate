using System;
using System.Collections.Generic;

namespace RealEstate.ViewModels
{
    public class GetChatViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GetMessageViewModel> Messages { get; set; }
        public int PagesCount { get; set; }
    }
}
