using Adingisa.Dtos;
using Adingisa.Models;
using Adingisa.Repositories;

namespace Adingisa.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            var posts = await _repository.GetAllAsync();
            return posts ?? new List<Post>();
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            var posts = await _repository.GetAllAsync();
            return posts ?? new List<Post>();
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Post> CreateAsync(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            return await _repository.CreateAsync(post);
        }

        public async Task<Post> CreatePostAsync(PostCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var post = new Post
            {
                Content = dto.Content
            };
            return await _repository.CreateAsync(post);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}