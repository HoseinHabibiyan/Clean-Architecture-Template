using CleanArc.Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CleanArc.Identity.Infrastructure.Identity.Store;

public class RoleStore : RoleStore<Role, IdentityDbContext, int, UserRole, RoleClaim>
{
	public RoleStore(IdentityDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
	{
	}
}