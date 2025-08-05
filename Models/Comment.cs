namespace Adingisa.Models;

public class Comment
{
    public int CommentId { get; set; }
    public string Content { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Reply>? Replies { get; set; }


    // Existing relationships
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    // NEW: Relationship to TaxiRoute
    public int? TaxiRouteId { get; set; }
    public TaxiRoute? TaxiRoute { get; set; }

    // Replies
    public int? ReplyId { get; set; }
    public Reply? Reply { get; set; }
}
