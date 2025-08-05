namespace Adingisa.Dtos;

public class CommentCreateDto
{
    public string Content { get; set; } = null!;
    public int UserId { get; set; }
    public int ReplyId { get; set; }

    public int? TaxiRouteId { get; set; } 
}
