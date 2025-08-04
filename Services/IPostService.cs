using Adingisa.Dtos;
using Adingisa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adingisa.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetAllPostsAsync(); // Added
        Task<Post?> GetByIdAsync(int id);
        Task<Post> CreateAsync(Post post);
        Task<Post> CreatePostAsync(PostCreateDto dto); // Added
        Task<bool> DeleteAsync(int id);
    }
}