using CleanArc.Order.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArc.Bootstrapper;

public static class OrderBootstrapper
{
    public static IServiceCollection AddOrderBootstrapper(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContextPool<OrderDbContext>(options =>
        {
            options
                .UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        return services;
    }
}