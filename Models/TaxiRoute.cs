// Models/TaxiRoute.cs
namespace Adingisa.Models
{
    public class TaxiRoute
    {
        public int TaxiRouteId { get; set; }
        public required string StartLocation { get; set; }
        public required string EndLocation { get; set; }

    }
}
