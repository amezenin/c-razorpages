using System.ComponentModel.DataAnnotations;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class Farmer
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Firstname { get; set; }
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Lastname { get; set; }
        public int Score { get; set; }
        
       // public ICollection<AnsweredQuestion> AnsweredQuestions { get; set; }

       // public ICollection<PersonQuestion> PersonQuestions { get; set; }
    }
}