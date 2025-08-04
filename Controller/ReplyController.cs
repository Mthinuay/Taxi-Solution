using Microsoft.AspNetCore.Mvc;
using Adingisa.Dtos;
using Adingisa.Services;

[ApiController]
[Route("api/[controller]")]
public class ReplyController : ControllerBase
{
    private readonly IReplyService _replyService;

    public ReplyController(IReplyService replyService)
    {
        _replyService = replyService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReply([FromBody] ReplyCreateDto dto)
    {
        var result = await _replyService.CreateReplyAsync(dto);
        return Ok(result);
    }
}
