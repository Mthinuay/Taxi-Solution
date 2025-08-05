// Repositories/Interfaces/ITaxiRouteRepository.cs
using Adingisa.Models;

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
    }
}
