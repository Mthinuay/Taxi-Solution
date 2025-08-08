namespace Adingisa.Dtos
{
    public class TaxiLocationReadDto
    {
        public int TaxiLocationId { get; set; }
        public string LocationName { get; set; } = null!;
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}