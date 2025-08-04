namespace Adingisa.Dtos;

public class ReplyResponseDto
{
    public int ReplyID { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int UserID { get; set; }
    public string? UserName { get; set; }
}
