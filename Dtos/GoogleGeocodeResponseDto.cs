using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Adingisa.Dtos
{
    public class GoogleGeocodeResponse
    {
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; } = new();

        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;
    }

    public class Result
    {
        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; } = null!;
    }

    public class Geometry
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; } = null!;
    }

    public class Location
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }
    }
}
