using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularArc.Identity.Services;
using ModularArc.Order.Application.Repositories;
using ModularArc.Order.Application.Services;
using ModularArc.Order.Data;
using ModularArc.SharedKernel.Contracts.Persistence;

namespace ModularArc.Bootstrapper;

public static class OrderBootstrapper
{
    public static IServiceCollection AddOrderBootstrapper(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<OrderDbContext>(options =>
        {
            options
                .UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IPersistanceProvider, OrderRepository>();

        services.AddGrpc();
        services.AddGrpcReflection();

        return services;
    }

    public static void ConfigureGrpcPipeline(this WebApplication app)
    {
        app.MapGrpcService<UserGrpcServices>();
        app.MapGrpcService<OrderGrpcServices>();
        app.MapGrpcReflectionService();

        app.MapGet("/GrpcUser", async context =>
        {
            await context.Response.WriteAsync(
                "Communication with this gRPC endpoint must be made through a gRPC client.");
        });

        app.MapGet("/GrpcUserOrder", async context =>
        {
            await context.Response.WriteAsync(
                "Communication with this gRPC endpoint must be made through a gRPC client.");
        });
    }
}