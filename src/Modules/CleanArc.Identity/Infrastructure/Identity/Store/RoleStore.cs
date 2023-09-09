using CleanArc.Identity.Data;
using CleanArc.Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CleanArc.Identity.Infrastructure.Identity.Store;

public class RoleStore : RoleStore<Role, IdentityAppDbContext, int, UserRole, RoleClaim>
{
	public RoleStore(IdentityAppDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
	{
	}
}