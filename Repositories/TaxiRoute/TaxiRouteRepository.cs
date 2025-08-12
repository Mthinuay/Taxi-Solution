// Repositories/TaxiRouteRepository.cs
using Adingisa.Data;
using Adingisa.Models;
using Adingisa.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Adingisa.Repositories
{
    public class TaxiRouteRepository : ITaxiRouteRepository
    {
        private readonly AppDbContext _context;

        public TaxiRouteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaxiRoute>> GetAllAsync()
        {
            return await _context.TaxiRoutes.ToListAsync();
        }

        public async Task<TaxiRoute?> GetByIdAsync(int id)
        {
            return await _context.TaxiRoutes.FindAsync(id);
        }

        public async Task AddAsync(TaxiRoute route)
        {
            await _context.TaxiRoutes.AddAsync(route);
        }

        public void Update(TaxiRoute route)
        {
            _context.TaxiRoutes.Update(route);
        }

        public void Delete(TaxiRoute route)
        {
            _context.TaxiRoutes.Remove(route);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<TaxiRoute?> FindAsync(Expression<Func<TaxiRoute, bool>> predicate)
        {
            return await _context.TaxiRoutes.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TaxiRoute>> FindAllAsync(Expression<Func<TaxiRoute, bool>> predicate)
        {
            return await _context.TaxiRoutes
                .Where(predicate)
                .ToListAsync();
        }

    }
}
