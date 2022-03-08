using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Domain
{
    public class Question : DomainEntity
    {
        
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public int QuestionGivesScore { get; set; }
        public int QuestionMinScore { get; set; }
        public int QuestionMaxScore { get; set; }


        public ICollection<AnsweredQuestion> AnsweredQuestions { get; set; }
        public ICollection<PersonQuestion> PersonQuestions { get; set; }

     
        
    }
}