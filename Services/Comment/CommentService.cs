using Adingisa.Dtos;
using Adingisa.Models;
using Adingisa.Repositories;

namespace Adingisa.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Comment> CreateAsync(CommentCreateDto dto)
        {
            var comment = new Comment
            {
                Content = dto.Content,
                UserID = dto.UserID,
                ReplyID = dto.ReplyID,
                CreatedAt = DateTime.UtcNow
            };
            return await _repository.AddAsync(comment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}