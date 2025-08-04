namespace Adingisa.Dtos;

public class ReplyCreateDto
{
    public string Content { get; set; } = null!;
    public int PostID { get; set; }
    public int UserID { get; set; }
}
