﻿namespace RealEstate.BLL.DTO
{
    public class OfferFromUserDto
    {
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int PropertyId { get; set; }
        public int Status { get; set; }
        public string AgentId { get; set; }
    }
}
