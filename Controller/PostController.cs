using Adingisa.Dtos;
using Adingisa.Models;
using Adingisa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adingisa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            var posts = await _service.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            var post = await _service.GetByIdAsync(id);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(PostCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Post data is required.");
            }
            var created = await _service.CreatePostAsync(dto);
            return CreatedAtAction(nameof(GetPostById), new { id = created.PostId }, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}