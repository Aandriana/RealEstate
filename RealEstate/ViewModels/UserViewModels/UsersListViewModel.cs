﻿namespace RealEstateIdentity.ViewModels
{
    public class UsersListViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public AgentsListViewModel AgentProfile { get; set; }
    }
}
