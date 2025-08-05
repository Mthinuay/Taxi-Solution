namespace Adingisa.Models;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int RoleId { get; set; }
    public bool IsPaymentVerified { get; set; } = false;

    public Role? Role { get; set; }

    public ICollection<Post>? Posts { get; set; }
    public ICollection<Reply>? Replies { get; set; }
    


}
