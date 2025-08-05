namespace Adingisa.Models;

public class Post
{
    public int PostId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key to the user who created the post
    public int UserId { get; set; }
    public User? User { get; set; }

    public ICollection<Reply> Replies { get; set; } = new List<Reply>();
}
