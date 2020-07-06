using System;
using System.Collections.Generic;

namespace RealEstate.BLL.DTO.UserDtos
{
    public class GetAgentByIdInfoDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public double DefaultRate { get; set; }
        public int SuccessSales { get; set; }
        public int FailedSales { get; set; }
        public double Rating { get; set; }
        public virtual ICollection<FeedbackListDto> FeedBacks { get; set; }
    }
}
