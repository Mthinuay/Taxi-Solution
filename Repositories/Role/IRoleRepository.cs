using Adingisa.Models;

namespace Adingisa.Repositories;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role?> GetByIdAsync(int id);
    Task<Role> CreateAsync(Role role);
    Task<bool> DeleteAsync(int id);
}
