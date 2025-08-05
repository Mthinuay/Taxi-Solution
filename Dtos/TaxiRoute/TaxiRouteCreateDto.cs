// Dtos/TaxiRouteCreateDto.cs
namespace Adingisa.Dtos
{
    public class TaxiRouteCreateDto
    {
        public string StartLocation { get; set; } = null!;
        public string EndLocation { get; set; } = null!;
    }
}
