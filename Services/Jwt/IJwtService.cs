using Adingisa.Models;

namespace Adingisa.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}