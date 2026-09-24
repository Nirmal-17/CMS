using Cms.Domain.Entities;

namespace Cms.Application.Abstractions;

public interface IBlogRepository
{
    Task<IReadOnlyList<BlogPost>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<BlogPost?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(BlogPost post, CancellationToken cancellationToken = default);
    void Update(BlogPost post);
    void Remove(BlogPost post);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
