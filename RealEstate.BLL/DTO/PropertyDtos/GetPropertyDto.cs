﻿using System.Collections.Generic;

namespace RealEstate.BLL.DTO
{
    public class GetPropertyDto
    {
        public double Size { get; set; }
        public int Category { get; set; }
        public int FloorsNumber { get; set; }
        public int Floors { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int BuildYear { get; set; }
        public int Status { get; set; }
        public virtual ICollection<OfferDto> OfferDtos { get; set; }
        public virtual ICollection<string> PhotosDtos { get; set; }
        public virtual ICollection<QuestionsDto> QuestionsDtos { get; set; }
    }
}
