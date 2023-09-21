using BlogApi.Models;

namespace BlogApi.Dtos;

public class CommentDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Post PostId { get; set; }
    public string Text { get; set; }
}