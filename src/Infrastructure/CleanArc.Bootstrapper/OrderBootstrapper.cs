using CleanArc.Order.Application.Repositories;
using CleanArc.Order.Data;
using CleanArc.SharedKernel.Contracts.Persistence;
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

		services.AddScoped<IUnitOfWork, UnitOfWork>();

		services.AddScoped<IPersistanceProvider, OrderRepository>();

		return services;
    }
}