// Services/TaxiRouteService.cs
using Adingisa.Dtos;
using Adingisa.Models;
using Adingisa.Repositories.Interfaces;
using Adingisa.Services.Interfaces;

namespace Adingisa.Services
{
    public class TaxiRouteService : ITaxiRouteService
    {
        private readonly ITaxiRouteRepository _repository;

        public TaxiRouteService(ITaxiRouteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaxiRouteResponseDto>> GetAllAsync()
        {
            var routes = await _repository.GetAllAsync();
            return routes.Select(r => new TaxiRouteResponseDto
            {
                TaxiRouteId = r.TaxiRouteId,
                StartLocation = r.StartLocation,
                EndLocation = r.EndLocation
            });
        }

        public async Task<TaxiRouteResponseDto?> GetByIdAsync(int id)
        {
            var route = await _repository.GetByIdAsync(id);
            if (route == null) return null;

            return new TaxiRouteResponseDto
            {
                TaxiRouteId = route.TaxiRouteId,
                StartLocation = route.StartLocation,
                EndLocation = route.EndLocation
            };
        }

        public async Task<TaxiRouteResponseDto> CreateAsync(TaxiRouteCreateDto dto)
        {
            var route = new TaxiRoute
            {
                StartLocation = dto.StartLocation,
                EndLocation = dto.EndLocation
            };

            await _repository.AddAsync(route);
            await _repository.SaveAsync();

            return new TaxiRouteResponseDto
            {
                TaxiRouteId = route.TaxiRouteId,
                StartLocation = route.StartLocation,
                EndLocation = route.EndLocation
            };
        }

        public async Task<TaxiRouteResponseDto?> SearchByDestinationAsync(string destination)
{
    var route = await _repository
        .FindAsync(r => r.EndLocation.ToLower() == destination.ToLower());

    if (route == null) return null;

    return new TaxiRouteResponseDto
    {
        TaxiRouteId = route.TaxiRouteId,
        StartLocation = route.StartLocation,
        EndLocation = route.EndLocation,
        Fare = route.Fare,
        PickupLocation = route.PickupLocation
    };
}

        public async Task<bool> UpdateAsync(int id, TaxiRouteCreateDto dto)
        {
            var route = await _repository.GetByIdAsync(id);
            if (route == null) return false;

            route.StartLocation = dto.StartLocation;
            route.EndLocation = dto.EndLocation;

            _repository.Update(route);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var route = await _repository.GetByIdAsync(id);
            if (route == null) return false;

            _repository.Delete(route);
            await _repository.SaveAsync();
            return true;
        }
    }
}
