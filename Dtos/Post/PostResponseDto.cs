namespace Adingisa.Dtos;

public class PostResponseDto
{
    public int PostId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public string? UserName { get; set; }

    public List<ReplyResponseDto>? Replies { get; set; }
}
