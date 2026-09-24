using System.ComponentModel.DataAnnotations;

namespace Cms.Application.Models;

public record BlogPostDto(
    int Id,
    string Title,
    string Summary,
    string Content,
    string AuthorName,
    DateTime CreatedAt,
    DateTime UpdatedAt);

public class BlogPostInput
{
    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string Summary { get; set; } = string.Empty;

    [Required]
    [StringLength(20000, MinimumLength = 10)]
    public string Content { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string AuthorName { get; set; } = string.Empty;
}
