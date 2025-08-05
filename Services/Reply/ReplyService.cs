using Adingisa.Dtos; // Added for ReplyCreateDto
using Adingisa.Models;
using Adingisa.Repositories;

namespace Adingisa.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IReplyRepository _repository;

        public ReplyService(IReplyRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Reply>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Reply?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Reply> CreateAsync(Reply reply)
        {
            if (reply == null)
            {
                throw new ArgumentNullException(nameof(reply));
            }
            return await _repository.CreateAsync(reply);
        }

        public async Task<Reply> CreateReplyAsync(ReplyCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var reply = new Reply
            {
                Content = dto.Content,
                
            };
            return await _repository.CreateAsync(reply);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}