using CleanArc.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.Identity.Domain;

public class UserRole : IdentityUserRole<int>, IEntity
{
	public User User { get; set; }
	public Role Role { get; set; }
	public DateTime CreatedUserRoleDate { get; set; }

}