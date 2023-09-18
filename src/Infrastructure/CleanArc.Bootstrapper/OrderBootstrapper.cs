using CleanArc.Order.Application.Repositories;
using CleanArc.Order.Application.Services;
using CleanArc.Order.Data;
using CleanArc.SharedKernel.Contracts.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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