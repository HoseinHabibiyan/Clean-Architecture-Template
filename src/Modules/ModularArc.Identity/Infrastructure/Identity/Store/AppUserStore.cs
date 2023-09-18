using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ModularArc.Identity.Data;
using ModularArc.Identity.Domain;

namespace ModularArc.Identity.Infrastructure.Identity.Store;

public class AppUserStore : UserStore<User, Role, IdentityAppDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
{
    public AppUserStore(IdentityAppDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {
    }
}