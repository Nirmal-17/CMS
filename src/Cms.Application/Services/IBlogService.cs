using Cms.Application.Models;

namespace Cms.Application.Services;

public interface IBlogService
{
    Task<IReadOnlyList<BlogPostDto>> ListAsync(CancellationToken cancellationToken = default);
    Task<BlogPostDto?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<BlogPostDto> CreateAsync(BlogPostInput input, CancellationToken cancellationToken = default);
    Task<BlogPostDto?> UpdateAsync(int id, BlogPostInput input, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
