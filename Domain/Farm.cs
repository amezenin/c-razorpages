using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Farm : DomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public ICollection<Tank> Tanks { get; set; }

        public ICollection<Equipment> Equipments { get; set; }
        
    }
}