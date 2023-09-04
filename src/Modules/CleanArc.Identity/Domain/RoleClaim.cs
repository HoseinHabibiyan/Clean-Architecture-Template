using CleanArc.WebFramework.Base;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.Identity.Domain;

public class RoleClaim : IdentityRoleClaim<int>, IEntity
{
	public RoleClaim()
	{
		CreatedClaim = DateTime.Now;
	}

	public DateTime CreatedClaim { get; set; }
	public Role Role { get; set; }

}