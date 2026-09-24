using Cms.Application.Abstractions;
using Cms.Infrastructure.Data;
using Cms.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default")
            ?? "Data Source=cms.db";

        services.AddDbContext<CmsDbContext>(options => options.UseSqlite(connectionString));
        services.AddScoped<IBlogRepository, BlogRepository>();

        return services;
    }
}
