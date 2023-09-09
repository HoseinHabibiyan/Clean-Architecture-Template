using CleanArc.Identity.Data;
using CleanArc.Identity.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CleanArc.Identity.Infrastructure.Identity.Store;

public class AppUserStore : UserStore<User, Role, IdentityAppDbContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
{
	public AppUserStore(IdentityAppDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
	{
	}
}