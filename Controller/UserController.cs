using Adingisa.Dtos;
using Adingisa.Models;
using Adingisa.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adingisa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetUserById), new { id = created.UserID }, created);
        }

        [HttpPost("login")]
        public async Task<ActionResult<object>> Login(UserLoginDto dto)
        {
            var token = await _service.AuthenticateAsync(dto);
            if (token == null) 
                return Unauthorized("Invalid credentials or payment not verified.");

            return Ok(new { token });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/verify-payment")]
        public async Task<IActionResult> VerifyPayment(int id)
        {
            var success = await _service.VerifyPaymentAsync(id);
            return success ? Ok("Payment verified") : NotFound("User not found");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}