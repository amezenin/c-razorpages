using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Solution : DomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

      
        [Required]
        public string SolutionValue { get; set; }

        public string SolutionText { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
        
    }
}