using Adingisa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adingisa.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post?> GetByIdAsync(int id);
        Task<Post> CreateAsync(Post post);
        Task<bool> DeleteAsync(int id);
    }
}