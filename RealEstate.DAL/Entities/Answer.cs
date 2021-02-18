namespace RealEstate.DAL.Entities
{
    public class Answer : BaseEntity
    {
        public string AnswerText { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public string Question { get; set; }
    }

}
