namespace RealEstateIdentity.ViewModels.OfferViewModels
{
    public class OfferViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int PropertyId { get; set; }
        public int Status { get; set; }
        public string AgentProfileId { get; set; }
    }
}
