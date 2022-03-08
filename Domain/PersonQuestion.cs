namespace Domain
{
    public class PersonQuestion : DomainEntity
    {
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}