using Cms.Domain.Entities;
using Cms.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Infrastructure;

public static class DbInitializer
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CmsDbContext>();

        await context.Database.EnsureCreatedAsync();

        if (await context.BlogPosts.AnyAsync())
        {
            return;
        }

        var now = DateTime.UtcNow;
        context.BlogPosts.AddRange(
            new BlogPost
            {
                Title = "Welcome to the CMS",
                Summary = "A friendly place to read and write articles.",
                Content = "Anyone can publish here. Use the Write button to create your first article, then share the link with the world.",
                AuthorName = "Team CMS",
                CreatedAt = now,
                UpdatedAt = now
            },
            new BlogPost
            {
                Title = "Clean architecture in .NET 8",
                Summary = "Domain, Application, Infrastructure, and Web kept neatly separated.",
                Content = "This app is organized into four projects: Cms.Domain holds entities, Cms.Application holds use cases and contracts, Cms.Infrastructure implements data access with EF Core and SQLite, and Cms.Web exposes MVC pages and a REST API.",
                AuthorName = "Team CMS",
                CreatedAt = now.AddMinutes(-1),
                UpdatedAt = now.AddMinutes(-1)
            });

        await context.SaveChangesAsync();
    }
}
