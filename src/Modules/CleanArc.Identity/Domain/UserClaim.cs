using CleanArc.WebFramework.Base;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.Identity.Domain;

public class UserClaim : IdentityUserClaim<int>, IEntity
{
	public User User { get; set; }
}