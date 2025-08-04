namespace Adingisa.Dtos;

public class CommentResponseDto
{
    public int CommentID { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int UserID { get; set; }
    public int ReplyID { get; set; }
}
