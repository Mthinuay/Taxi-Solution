using Adingisa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adingisa.Repositories
{
    public interface ITaxiLocationRepository
    {
        Task<IEnumerable<TaxiLocation>> GetAllAsync();
        Task<TaxiLocation?> GetByIdAsync(int id);
        Task AddAsync(TaxiLocation taxiLocation);
        Task UpdateAsync(TaxiLocation taxiLocation);
        Task DeleteAsync(TaxiLocation taxiLocation);
        Task<bool> SaveChangesAsync();
    }
}