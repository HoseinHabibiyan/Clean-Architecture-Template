using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ModularArc.Identity.Data;
using ModularArc.Identity.Domain;

namespace ModularArc.Identity.Infrastructure.Identity.Store;

public class RoleStore : RoleStore<Role, IdentityAppDbContext, int, UserRole, RoleClaim>
{
    public RoleStore(IdentityAppDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {
    }
}