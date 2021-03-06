﻿using System.Collections.Generic;

namespace RealEstate.BLL.DTO
{
    public class PropertyUpdateDto
    {
        public double Size { get; set; }
        public int Сategory { get; set; }
        public int FloorsNumber { get; set; }
        public int Floors { get; set; }
        public double Price { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int BuildYear { get; set; }
        public virtual ICollection<QuestionsDto> QuestionsDtos { get; set; }
    }
}
