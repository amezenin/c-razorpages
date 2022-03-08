namespace PublicApi.v2.DTO
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
    }
}