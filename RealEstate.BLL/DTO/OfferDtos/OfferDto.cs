﻿namespace RealEstate.BLL.DTO
{
    public class OfferDto
    {
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int PropertyId { get; set; }
        public int Status { get; set; }
        public string AgentProfileId { get; set; }
    }
}
