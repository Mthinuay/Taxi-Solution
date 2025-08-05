namespace Adingisa.Models;

public class Reply
{
    public int ReplyId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User? User { get; set; }

    public int PostId { get; set; }
    public Post? Post { get; set; }

     public int CommentId { get; set; }
    public Comment Comment { get; set; } = null!;
}
