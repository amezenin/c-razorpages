using System.ComponentModel.DataAnnotations;

namespace PublicApi.v2.DTO
{
    public class Tank
    {
        public int Id { get; set; }
        [MaxLength(64)]
        [MinLength(1)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Dimension { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float AverageMass { get; set; }
        
        
        public float RealFcr { get; set; }
        public float RealNh { get; set; }
        public float RealNo { get; set; }

        public int FarmId { get; set; }
        public Farm Farm { get; set; }

        public int FishTypeId { get; set; }
        public FishType FishType { get; set; }
    }
}