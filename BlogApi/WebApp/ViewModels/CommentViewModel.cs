using BlogApi.Models;

namespace BlogApi.WebApp.ViewModels;

public class CommentViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Post PostId { get; set; }
    public string Text { get; set; }
}