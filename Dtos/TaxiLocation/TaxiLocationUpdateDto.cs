namespace Adingisa.Dtos
{
    public class TaxiLocationUpdateDto
    {
        public string LocationName { get; set; } = null!;
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}