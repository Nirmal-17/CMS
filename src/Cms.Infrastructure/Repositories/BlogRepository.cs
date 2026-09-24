using Cms.Application.Abstractions;
using Cms.Domain.Entities;
using Cms.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Cms.Infrastructure.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly CmsDbContext _context;

    public BlogRepository(CmsDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<BlogPost>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _context.BlogPosts
            .AsNoTracking()
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);

    public async Task<BlogPost?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.BlogPosts.FindAsync(new object[] { id }, cancellationToken);

    public async Task AddAsync(BlogPost post, CancellationToken cancellationToken = default) =>
        await _context.BlogPosts.AddAsync(post, cancellationToken);

    public void Update(BlogPost post) => _context.BlogPosts.Update(post);

    public void Remove(BlogPost post) => _context.BlogPosts.Remove(post);

    public Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _context.SaveChangesAsync(cancellationToken);
}
