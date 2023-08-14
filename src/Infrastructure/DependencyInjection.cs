using DotBooked.Application.Common.Interfaces;
using DotBooked.Infrastructure.Email;
using DotBooked.Infrastructure.Payments;
using DotBooked.Infrastructure.Persistence;
using DotBooked.Infrastructure.Persistence.Interceptors;
using DotBooked.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotBooked.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<EntitySaveChangesInterceptor>();
        services.AddScoped<DispatchDomainEventsInterceptor>();

        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"), builder =>
            {
                builder.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName);
                builder.EnableRetryOnFailure();
            }));

        services.AddScoped<ApplicationDbContextInitializer>();

        services.AddSingleton<IDateTime, DateTimeService>();

        services.AddScoped<IPaymentProvider, MockPaymentProvider>();
        services.AddScoped<IEmailProvider, MockEmailProvider>();

        return services;
    }
}
