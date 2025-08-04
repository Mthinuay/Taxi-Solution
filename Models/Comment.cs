namespace Adingisa.Models;

    public class Comment
    {
        public int CommentID { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int UserID { get; set; }
        public User? User { get; set; }

        public int ReplyID { get; set; }
        public Reply? Reply { get; set; }
    }

