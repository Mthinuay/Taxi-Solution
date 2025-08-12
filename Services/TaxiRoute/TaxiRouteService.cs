using Adingisa.Dtos;
using Adingisa.Models;
using Adingisa.Repositories.Interfaces;
using Adingisa.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                EndLocation = r.EndLocation,
                Fare = r.Fare,
                PickupLocation = r.PickupLocation
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
                EndLocation = route.EndLocation,
                Fare = route.Fare,
                PickupLocation = route.PickupLocation
            };
        }

        public async Task<TaxiRouteResponseDto> CreateAsync(TaxiRouteCreateDto dto)
        {
            var route = new TaxiRoute
            {
                StartLocation = dto.StartLocation,
                EndLocation = dto.EndLocation,
                Fare = dto.Fare,
                PickupLocation = dto.PickupLocation
            };

            await _repository.AddAsync(route);
            await _repository.SaveAsync();

            return new TaxiRouteResponseDto
            {
                TaxiRouteId = route.TaxiRouteId,
                StartLocation = route.StartLocation,
                EndLocation = route.EndLocation,
                Fare = route.Fare,
                PickupLocation = route.PickupLocation
            };
        }

        public async Task<TaxiRouteResponseDto?> SearchByDestinationAsync(string destination)
        {
            var route = await _repository.FindAsync(r => r.EndLocation.ToLower() == destination.ToLower());

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

        public async Task<IEnumerable<TaxiRouteResponseDto>> SearchRoutesAsync(string destination, string? startRank = null)
        {
            IEnumerable<TaxiRoute> routes;

            if (string.IsNullOrWhiteSpace(startRank))
            {
                routes = await _repository.FindAllAsync(
                    r => r.EndLocation.ToLower().Contains(destination.ToLower()) ||
                         r.StartLocation.ToLower().Contains(destination.ToLower()));
            }
            else
            {
                routes = await _repository.FindAllAsync(
                    r => r.EndLocation.ToLower().Contains(destination.ToLower()) &&
                         r.StartLocation.ToLower().Contains(startRank.ToLower()));
            }

            return routes.Select(r => new TaxiRouteResponseDto
            {
                TaxiRouteId = r.TaxiRouteId,
                StartLocation = r.StartLocation,
                EndLocation = r.EndLocation,
                Fare = r.Fare,
                PickupLocation = r.PickupLocation
            });
        }

        public async Task<IEnumerable<TaxiRouteResponseDto>> SearchRoutesAsync(string destination)
        {
            var routes = await _repository.FindAllAsync(
                r => r.EndLocation.ToLower().Contains(destination.ToLower()) ||
                     r.StartLocation.ToLower().Contains(destination.ToLower()));

            return routes.Select(r => new TaxiRouteResponseDto
            {
                TaxiRouteId = r.TaxiRouteId,
                StartLocation = r.StartLocation,
                EndLocation = r.EndLocation,
                Fare = r.Fare,
                PickupLocation = r.PickupLocation
            });
        }

        public async Task<bool> UpdateAsync(int id, TaxiRouteCreateDto dto)
        {
            var route = await _repository.GetByIdAsync(id);
            if (route == null) return false;

            route.StartLocation = dto.StartLocation;
            route.EndLocation = dto.EndLocation;
            route.Fare = dto.Fare;
            route.PickupLocation = dto.PickupLocation;

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