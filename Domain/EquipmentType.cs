using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class EquipmentType : DomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        public ICollection<Equipment> Equipments { get; set; }
    }
}