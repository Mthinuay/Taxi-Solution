namespace Adingisa.Dtos;

public class CommentResponseDto
{
    public int CommentId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public int ReplyId { get; set; }
}
