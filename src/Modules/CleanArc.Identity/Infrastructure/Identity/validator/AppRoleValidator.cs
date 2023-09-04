using CleanArc.Identity.Domain;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.Identity.Infrastructure.Identity.validator;

public class AppRoleValidator : RoleValidator<Role>
{
	public AppRoleValidator(IdentityErrorDescriber errors) : base(errors)
	{

	}

	public override Task<IdentityResult> ValidateAsync(RoleManager<Role> manager, Role role)
	{
		return base.ValidateAsync(manager, role);
	}
}