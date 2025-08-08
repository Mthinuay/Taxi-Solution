namespace Adingisa.Dtos
{
    public class TaxiLocationCreateDto
    {
        public string LocationName { get; set; } = null!;
        public string? Description { get; set; }
        public double? Latitude { get; set; }  // Changed to nullable
        public double? Longitude { get; set; } // Changed to nullable
    }
}