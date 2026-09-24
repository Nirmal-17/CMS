using Cms.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBlogService, BlogService>();
        return services;
    }
}
