// Dtos/TaxiRouteResponseDto.cs
namespace Adingisa.Dtos
{
    public class TaxiRouteResponseDto
    {
        public int TaxiRouteId { get; set; }
        public string StartLocation { get; set; } = null!;
        public string EndLocation { get; set; } = null!;
    }
}
