using DotBooked.Application.Common.Interfaces;
using DotBooked.Infrastructure.Persistence;
using DotBooked.WebApi.Services;

namespace DotBooked.WebApi;

public static class DependencyInjection
{
    public static void AddWebApi(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddOpenApiDocument(configure => configure.Title = "Cafe365 API");

        services.AddEndpointsApiExplorer();
    }
}