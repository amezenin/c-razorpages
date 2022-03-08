using System.ComponentModel.DataAnnotations;

namespace PublicApi.v2.DTO
{
    public class Solution
    {
        public int Id { get; set; }
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