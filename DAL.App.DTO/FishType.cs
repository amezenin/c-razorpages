using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class FishType
    {
        public int Id { get; set; }
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Species { get; set; }
        
        public int MinTemp { get; set; }
        
        public int MaxTemp { get; set; }
        public float MaxNo { get; set; }
        public float MaxNh { get; set; }
        public int MaxDensity { get; set; }
    }
}