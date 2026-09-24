using Cms.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cms.Infrastructure.Data;

public class CmsDbContext : DbContext
{
    public CmsDbContext(DbContextOptions<CmsDbContext> options) : base(options)
    {
    }

    public DbSet<BlogPost> BlogPosts => Set<BlogPost>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogPost>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired().HasMaxLength(200);
            entity.Property(x => x.Summary).HasMaxLength(500);
            entity.Property(x => x.Content).IsRequired();
            entity.Property(x => x.AuthorName).IsRequired().HasMaxLength(100);
            entity.HasIndex(x => x.CreatedAt);
        });
    }
}
