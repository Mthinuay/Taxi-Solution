using Adingisa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adingisa.Repositories
{
    public interface IReplyRepository
    {
        Task<IEnumerable<Reply>> GetAllAsync();
        Task<Reply?> GetByIdAsync(int id);
        Task<Reply> CreateAsync(Reply reply);
        Task<bool> DeleteAsync(int id);
    }
}