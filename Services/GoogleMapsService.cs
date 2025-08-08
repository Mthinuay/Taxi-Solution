using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Adingisa.Dtos; 


public class GoogleMapsService
{
    private readonly HttpClient _http;
    private readonly string _apiKey;

    public GoogleMapsService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _apiKey = config["GoogleMaps:ApiKey"] ?? throw new InvalidOperationException("Missing Google Maps API key");
    }

    public async Task<(double lat, double lng)?> GeocodeAsync(string address)
    {
        var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";
        var resp = await _http.GetFromJsonAsync<GoogleGeocodeResponse>(url);
        if (resp?.Results?.Any() == true)
        {
            var loc = resp.Results[0].Geometry.Location;
            return (loc.Lat, loc.Lng);
        }
        return null;
    }

   
}
