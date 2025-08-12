// Repositories/Interfaces/ITaxiRouteRepository.cs
using Adingisa.Models;
using System.Linq.Expressions;


namespace Adingisa.Repositories.Interfaces
{
    public interface ITaxiRouteRepository
    {
        Task<IEnumerable<TaxiRoute>> GetAllAsync();
        Task<TaxiRoute?> GetByIdAsync(int id);

        Task AddAsync(TaxiRoute route);
        void Update(TaxiRoute route);
        void Delete(TaxiRoute route);
        Task SaveAsync();

        Task<TaxiRoute?> FindAsync(Expression<Func<TaxiRoute, bool>> predicate);
        Task<IEnumerable<TaxiRoute>> FindAllAsync(Expression<Func<TaxiRoute, bool>> predicate);
      
    }
}
