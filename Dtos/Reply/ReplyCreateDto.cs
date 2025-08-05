namespace Adingisa.Dtos;

public class ReplyCreateDto
{
    public string Content { get; set; } = null!;
    public int PostId { get; set; }
    public int UserId { get; set; }
}
