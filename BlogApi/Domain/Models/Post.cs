namespace BlogApi.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Body { get; set; }

    public List<Comment> Comments { get; set; }
}