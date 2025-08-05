using Adingisa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adingisa.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
        Task<Role> CreateAsync(Role role);
        Task<bool> DeleteAsync(int id);
    }
}