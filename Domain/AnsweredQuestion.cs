namespace Domain
{
    public class AnsweredQuestion : DomainEntity
    {
        public bool Value { get; set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}