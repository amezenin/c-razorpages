using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Equipment : DomainEntity
    {
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        public int FarmId { get; set; }
        public Farm Farm { get; set; }

        public int EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; }
    }
}