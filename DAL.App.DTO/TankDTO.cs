

using System.Reflection;

namespace DAL.App.DTO
{
    public class TankDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int Dimension { get; set; }
        
        public int Quantity { get; set; }
       
        public float AverageMass { get; set; }
        
        
        public float RealFcr { get; set; }
        public float RealNh { get; set; }
        public float RealNo { get; set; }

        public int FarmId { get; set; }
        public Farm Farm { get; set; }

        public int FishTypeId { get; set; }
        public FishType FishType { get; set; }

        public float Biomass { get; set; }
        
        public float FeedKg { get; set; }
        
        public float GrowingDay { get; set; }
        
        public float NewBiomass { get; set; }

        public float FeedPercent { get; set; }

        public float Density { get; set; }

        public float NewAverage { get; set; }
    }
}