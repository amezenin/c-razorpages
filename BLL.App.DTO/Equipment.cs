using System.ComponentModel.DataAnnotations;

namespace BLL.App.DTO
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