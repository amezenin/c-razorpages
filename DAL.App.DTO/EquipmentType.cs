using System.ComponentModel.DataAnnotations;

namespace DAL.App.DTO
{
    public class EquipmentType
    {
        public int Id { get; set; }
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }

        //public ICollection<Equipment> Equipments { get; set; }
    }
}