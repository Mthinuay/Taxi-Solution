using Adingisa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adingisa.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<bool> UpdateAsync(User user); // Changed from Task to Task<bool>
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Role>> GetAllRolesAsync();


    
    }
}