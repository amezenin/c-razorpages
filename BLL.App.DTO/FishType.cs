using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
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

        //public ICollection<Tank> Tanks { get; set; }
    }
}