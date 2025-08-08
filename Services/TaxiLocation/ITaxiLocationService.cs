using Adingisa.Dtos;
using Adingisa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adingisa.Services
{
   public interface ITaxiLocationService
    {
        Task<IEnumerable<TaxiLocationReadDto>> GetAllAsync();
        Task<TaxiLocationReadDto?> GetByIdAsync(int id);
        Task<TaxiLocationReadDto> CreateAsync(TaxiLocationCreateDto dto);
        Task<bool> UpdateAsync(int id, TaxiLocationUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}