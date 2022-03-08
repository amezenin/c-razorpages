using System.ComponentModel.DataAnnotations;

namespace PublicApi.v1.DTO
{
    public class Equipment
    {
        public int Id { get; set; }
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