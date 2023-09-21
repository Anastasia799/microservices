using AuthApi.Domain.Models;

namespace BlogApi.Models;

public class Comment
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Post PostId { get; set; }
    public string Text { get; set; }
    
    public User User { get; set; }
    public Post Post { get; set; }
}