namespace Cms.Domain.Entities;

public class BlogPost
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Summary { get; set; } = string.Empty;
    public required string Content { get; set; }
    public required string AuthorName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
