using Adingisa.Dtos;

namespace Adingisa.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(UserCreateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> VerifyPaymentAsync(int id);
        Task<string?> AuthenticateAsync(UserLoginDto dto);
    }
}