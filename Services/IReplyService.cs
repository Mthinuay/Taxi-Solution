using Adingisa.Dtos;
using Adingisa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adingisa.Services
{
    public interface IReplyService
    {
        Task<IEnumerable<Reply>> GetAllAsync();
        Task<Reply?> GetByIdAsync(int id);
        Task<Reply> CreateAsync(Reply reply);
        Task<Reply> CreateReplyAsync(ReplyCreateDto dto); // Added to match error
        Task<bool> DeleteAsync(int id);
    }
}