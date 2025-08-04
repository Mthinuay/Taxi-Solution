namespace Adingisa.Models;

public class Reply
{
    public int ReplyID { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserID { get; set; }
    public User? User { get; set; }

    public int PostID { get; set; }
    public Post? Post { get; set; }

    public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
}
