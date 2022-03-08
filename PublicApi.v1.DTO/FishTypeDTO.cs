namespace PublicApi.v1.DTO
{
    public class FishTypeDTO
    {
        public int Id { get; set; }
        
        public string Species { get; set; }
        
        public int MinTemp { get; set; }
        
        public int MaxTemp { get; set; }
        public float MaxNo { get; set; }
        public float MaxNh { get; set; }
        public int MaxDensity { get; set; }

        public int TankCount { get; set; }
    }
}