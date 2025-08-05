using Adingisa.Models;
public class TaxiRoute
{
    public int TaxiRouteId { get; set; }
    public string StartLocation { get; set; } = null!;
    public string EndLocation { get; set; } = null!;

    // NEW: Comments on this route
    public ICollection<Comment>? Comments { get; set; }
}
