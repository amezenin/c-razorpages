using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Answer : DomainEntity
    {
        
        [Required]
        public string AnswerValueFirst { get; set; }
        [Required]
        public string AnswerValueSecond { get; set; }
        [Required]
        public string AnswerValueThird { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
        
        
    }
}