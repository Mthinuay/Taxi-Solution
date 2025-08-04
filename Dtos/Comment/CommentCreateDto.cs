namespace Adingisa.Dtos;

public class CommentCreateDto
{
    public string Content { get; set; } = null!;
    public int UserID { get; set; }
    public int ReplyID { get; set; }
}
