using Adingisa.Dtos;
using Adingisa.Models;
using Adingisa.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Adingisa.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository repository, IPasswordHasher<User> passwordHasher, IJwtService jwtService)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<string?> AuthenticateAsync(UserLoginDto dto)
        {
            var users = await _repository.GetAllAsync();
            var user = users.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null) return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result != PasswordVerificationResult.Success || !user.IsPaymentVerified) return null;

            return _jwtService.GenerateToken(user);
        }

        public async Task<bool> VerifyPaymentAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return false;

            user.IsPaymentVerified = true;
            await _repository.UpdateAsync(user);
            return true;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                RoleName = u.Role?.RoleName ?? "Unknown"
            });
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                RoleName = user.Role?.RoleName ?? "Unknown"
            };
        }

        public async Task<UserDto> CreateAsync(UserCreateDto dto)
        {
            // Fetch all roles and find the default "User" role
            var roles = await _repository.GetAllRolesAsync();
            var defaultRole = roles.FirstOrDefault(r => r.RoleName == "User");

            if (defaultRole == null)
            {
                throw new Exception("Default role 'User' not found in the database.");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                RoleId = defaultRole.RoleId // Auto-assign default role
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            var created = await _repository.CreateAsync(user);

            return new UserDto
            {
                UserId = created.UserId,
                Name = created.Name,
                Email = created.Email,
                RoleName = created.Role?.RoleName ?? "Unknown"
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
