using Cms.Application.Abstractions;
using Cms.Application.Models;
using Cms.Domain.Entities;

namespace Cms.Application.Services;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _repository;

    public BlogService(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<BlogPostDto>> ListAsync(CancellationToken cancellationToken = default)
    {
        var posts = await _repository.GetAllAsync(cancellationToken);
        return posts.Select(ToDto).ToList();
    }

    public async Task<BlogPostDto?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var post = await _repository.GetByIdAsync(id, cancellationToken);
        return post is null ? null : ToDto(post);
    }

    public async Task<BlogPostDto> CreateAsync(BlogPostInput input, CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;
        var post = new BlogPost
        {
            Title = input.Title.Trim(),
            Summary = input.Summary.Trim(),
            Content = input.Content.Trim(),
            AuthorName = input.AuthorName.Trim(),
            CreatedAt = now,
            UpdatedAt = now
        };

        await _repository.AddAsync(post, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return ToDto(post);
    }

    public async Task<BlogPostDto?> UpdateAsync(int id, BlogPostInput input, CancellationToken cancellationToken = default)
    {
        var post = await _repository.GetByIdAsync(id, cancellationToken);
        if (post is null)
        {
            return null;
        }

        post.Title = input.Title.Trim();
        post.Summary = input.Summary.Trim();
        post.Content = input.Content.Trim();
        post.AuthorName = input.AuthorName.Trim();
        post.UpdatedAt = DateTime.UtcNow;

        _repository.Update(post);
        await _repository.SaveChangesAsync(cancellationToken);

        return ToDto(post);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var post = await _repository.GetByIdAsync(id, cancellationToken);
        if (post is null)
        {
            return false;
        }

        _repository.Remove(post);
        await _repository.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static BlogPostDto ToDto(BlogPost post) =>
        new(post.Id, post.Title, post.Summary, post.Content, post.AuthorName, post.CreatedAt, post.UpdatedAt);
}
