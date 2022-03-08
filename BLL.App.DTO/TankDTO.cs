namespace BLL.App.DTO
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

        public double Biomass { get; set; }

        public double FeedKg { get; set; }
        
        public double GrowingDay { get; set; }
        
        public double NewBiomass { get; set; }

        public double FeedPercent { get; set; }

        public double Density { get; set; }
        public double NewAverage { get; set; }
    }
}