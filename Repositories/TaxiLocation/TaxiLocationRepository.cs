using Adingisa.Data;
using Adingisa.Models;
using Microsoft.EntityFrameworkCore;

namespace Adingisa.Repositories
{
    public class TaxiLocationRepository : ITaxiLocationRepository
    {
        private readonly AppDbContext _context;

        public TaxiLocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaxiLocation>> GetAllAsync() =>
            await _context.TaxiLocations.ToListAsync();

        public async Task<TaxiLocation?> GetByIdAsync(int id) =>
            await _context.TaxiLocations.FindAsync(id);

        public async Task AddAsync(TaxiLocation taxiLocation) =>
            await _context.TaxiLocations.AddAsync(taxiLocation);

        public Task UpdateAsync(TaxiLocation taxiLocation)
        {
            _context.TaxiLocations.Update(taxiLocation);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TaxiLocation taxiLocation)
        {
            _context.TaxiLocations.Remove(taxiLocation);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync() =>
            await _context.SaveChangesAsync() > 0;
    }
}
