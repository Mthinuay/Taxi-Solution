using Adingisa.Data;
using Adingisa.Models;
using Microsoft.EntityFrameworkCore;

namespace Adingisa.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly AppDbContext _context;

        public ReplyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reply>> GetAllAsync()
        {
            return await _context.Replies.ToListAsync();
        }

        public async Task<Reply?> GetByIdAsync(int id)
        {
            return await _context.Replies.FindAsync(id);
        }

        public async Task<Reply> CreateAsync(Reply reply)
        {
            _context.Replies.Add(reply);
            await _context.SaveChangesAsync();
            return reply;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reply = await _context.Replies.FindAsync(id);
            if (reply == null) return false;

            _context.Replies.Remove(reply);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}