using Adingisa.Dtos;
using Adingisa.Models;
using Adingisa.Repositories;
using AutoMapper;

namespace Adingisa.Services
{
    public class TaxiLocationService : ITaxiLocationService
    {
        private readonly ITaxiLocationRepository _repo;
        private readonly IMapper _mapper;
        private readonly GoogleMapsService _maps;

        public TaxiLocationService(
            ITaxiLocationRepository repo, 
            IMapper mapper, 
            GoogleMapsService maps)
        {
            _repo = repo;
            _mapper = mapper;
            _maps = maps;
        }

        public async Task<IEnumerable<TaxiLocationReadDto>> GetAllAsync()
        {
            var locations = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<TaxiLocationReadDto>>(locations);
        }

        public async Task<TaxiLocationReadDto?> GetByIdAsync(int id)
        {
            var location = await _repo.GetByIdAsync(id);
            return location == null ? null : _mapper.Map<TaxiLocationReadDto>(location);
        }

        public async Task<TaxiLocationReadDto> CreateAsync(TaxiLocationCreateDto dto)
        {
            // If coordinates are missing, try geocoding the location name
            if (dto.Latitude == null || dto.Longitude == null)
            {
                var coords = await _maps.GeocodeAsync(dto.LocationName);

                if (coords.HasValue)
                {
                    dto.Latitude = coords.Value.lat;
                    dto.Longitude = coords.Value.lng;
                }
                else
                {
                    throw new InvalidOperationException(
                        $"Unable to geocode location '{dto.LocationName}'. Please provide valid coordinates."
                    );
                }
            }

            var location = _mapper.Map<TaxiLocation>(dto);
            await _repo.AddAsync(location);
            await _repo.SaveChangesAsync();

            return _mapper.Map<TaxiLocationReadDto>(location);
        }

        public async Task<bool> UpdateAsync(int id, TaxiLocationUpdateDto dto)
        {
            var location = await _repo.GetByIdAsync(id);
            if (location == null) return false;

            _mapper.Map(dto, location);
            await _repo.UpdateAsync(location);
            return await _repo.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var location = await _repo.GetByIdAsync(id);
            if (location == null) return false;

            await _repo.DeleteAsync(location);
            return await _repo.SaveChangesAsync();
        }
    }
}
