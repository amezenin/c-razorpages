using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class FishType : DomainEntity
    {

        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Species { get; set; }
        
        public int MinTemp { get; set; }
        
        public int MaxTemp { get; set; }
        public float MaxNo { get; set; }
        public float MaxNh { get; set; }
        public int MaxDensity { get; set; }

        public ICollection<Tank> Tanks { get; set; }
        
        
        
    }
}