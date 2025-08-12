// Services/Interfaces/ITaxiRouteService.cs
using Adingisa.Dtos;

namespace Adingisa.Services.Interfaces
{
    public interface ITaxiRouteService
    {
        Task<IEnumerable<TaxiRouteResponseDto>> GetAllAsync();
        Task<TaxiRouteResponseDto?> GetByIdAsync(int id);
        Task<TaxiRouteResponseDto> CreateAsync(TaxiRouteCreateDto dto);
        Task<bool> UpdateAsync(int id, TaxiRouteCreateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<TaxiRouteResponseDto?> SearchByDestinationAsync(string destination);
        Task<IEnumerable<TaxiRouteResponseDto>> SearchRoutesAsync(string destination);
        Task<IEnumerable<TaxiRouteResponseDto>> SearchRoutesAsync(string destination, string? startRank = null);

    }
}
