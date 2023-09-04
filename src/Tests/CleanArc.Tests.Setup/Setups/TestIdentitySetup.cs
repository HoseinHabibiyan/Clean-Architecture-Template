using CleanArc.Identity.Data;
using CleanArc.Identity.Domain;
using CleanArc.Identity.Infrastructure.Identity.Manager;
using CleanArc.Identity.Infrastructure.Identity.Store;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CleanArc.Identity.Infrastructure.Identity.Extensions;
using CleanArc.Identity.Infrastructure.Identity.Dtos;
using CleanArc.Identity.Infrastructure.Jwt;
using CleanArc.Identity.Infrastructure.UserManager;

namespace CleanArc.Tests.Setup.Setups;

public abstract class TestIdentitySetup
{
    protected IAppUserManager TestAppUserManager { get; }
    protected AppRoleManager TestAppRoleManager { get; }
    public AppSignInManager TestSignInManager { get; }
    public IAppUserManager User { get; }
    public IJwtService JwtService { get; }

    protected TestIdentitySetup()
    {
        var serviceCollection = new ServiceCollection();

        var connection = new SqliteConnection("DataSource=:memory:");

        serviceCollection.AddLogging();

        serviceCollection.AddDbContext<IdentityDbContext>(options => options.UseSqlite(connection));

        var context = serviceCollection.BuildServiceProvider().GetService<IdentityDbContext>();
        context.Database.OpenConnection();
        context.Database.EnsureCreated();


        serviceCollection.AddIdentity<User, Role>(options =>
        {
            options.Stores.ProtectPersonalData = false;

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireUppercase = false;

            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = true;

            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = false;
            options.User.RequireUniqueEmail = false;

        }).AddUserStore<AppUserStore>()
            .AddRoleStore<RoleStore>().
            AddUserManager<AppUserManager>().
            AddRoleManager<AppRoleManager>().
            AddDefaultTokenProviders().
            AddSignInManager<AppSignInManager>()
            .AddDefaultTokenProviders()
            .AddPasswordlessLoginTotpTokenProvider();

        serviceCollection.Configure<IdentitySettings>(settings =>
        {
            settings.Audience = "CleanArc.Unit.Tests";
            settings.ExpirationMinutes = 5;
            settings.Issuer = "CleanArc.Unit.Tests";
            settings.NotBeforeMinutes = 0;
            settings.SecretKey = "LongerThan-16Char-SecretKey";
            settings.Encryptkey = "16CharEncryptKey";
        });

        serviceCollection.AddScoped<IJwtService, JwtService>();
        serviceCollection.AddScoped<IAppUserManager, AppUserManagerImplementation>();

        TestAppUserManager = serviceCollection.BuildServiceProvider().GetRequiredService<IAppUserManager>();
        TestAppRoleManager = serviceCollection.BuildServiceProvider().GetRequiredService<AppRoleManager>();
        TestSignInManager = serviceCollection.BuildServiceProvider().GetRequiredService<AppSignInManager>();
        JwtService = serviceCollection.BuildServiceProvider().GetRequiredService<IJwtService>();
    }
}
