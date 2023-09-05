using System.Diagnostics;
using CleanArc.Application.ServiceConfiguration;
using CleanArc.Bootstrapper;
using CleanArc.Identity.Controllers.V1.UserManagement;
using CleanArc.Identity.Domain;
using CleanArc.Identity.Infrastructure.Identity.Dtos;
using CleanArc.Identity.Infrastructure.Jwt;
using CleanArc.Infrastructure.CrossCutting.Logging;
using CleanArc.SharedKernel.Extensions;
using CleanArc.WebFramework.Filters;
using CleanArc.WebFramework.Middlewares;
using CleanArc.WebFramework.ServiceConfiguration;
using CleanArc.WebFramework.Swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(LoggingConfiguration.ConfigureLogger);

var configuration = builder.Configuration;

Activity.DefaultIdFormat = ActivityIdFormat.W3C;

builder.Services.Configure<IdentitySettings>(configuration.GetSection(nameof(IdentitySettings)));

var identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(OkResultAttribute));
    options.Filters.Add(typeof(NotFoundResultAttribute));
    options.Filters.Add(typeof(ContentResultFilterAttribute));
    options.Filters.Add(typeof(ModelStateValidationAttribute));
    options.Filters.Add(typeof(BadRequestResultFilterAttribute));

}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
    options.SuppressMapClientErrors = true;
});

builder.Services.AddSwagger();

builder.Services
    .AddApplicationServices()
    .AddWebFrameworkServices()
    .AddOrderBootstrapper(configuration)
	.AddIdentityBootstrapper(configuration, identitySettings);

builder.Services.RegisterValidatorsAsServices();


#region Plugin Services Configuration

//builder.Services.ConfigureGrpcPluginServices();

#endregion

builder.Services.AddAutoMapper(typeof(User), typeof(JwtService), typeof(UserController));

var app = builder.Build();


#region Seeding and creating database

//await using (var scope = app.Services.CreateAsyncScope())
//{
//    var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

//    if (context is null)
//        throw new Exception("Database Context Not Found");

//    await context.Database.MigrateAsync();


//    var seedService = scope.ServiceProvider.GetRequiredService<ISeedDataBase>();
//    await seedService.Seed();
//}

#endregion

#region Pipleline Configuration

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCustomExceptionHandler();


app.UseSwaggerAndUI();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.ConfigureGrpcPipeline();

await app.RunAsync();
#endregion


