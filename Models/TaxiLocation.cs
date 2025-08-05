namespace Adingisa.Models;

public class TaxiLocation
{
    public int TaxiLocationId { get; set; }
    public string LocationName { get; set; } = null!;
    public string GPSCoordinates { get; set; } = null!;
    
    public ICollection<TaxiRoute>? TaxiRoutes { get; set; }
}
