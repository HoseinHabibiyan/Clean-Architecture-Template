using CleanArc.WebFramework.Base;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.Identity.Domain;

public class Role : IdentityRole<int>, IEntity
{
	public Role()
	{
		CreatedDate = DateTime.Now;
	}

	public string DisplayName { get; set; }
	public DateTime CreatedDate { get; set; }
	public ICollection<RoleClaim> Claims { get; set; }
	public ICollection<UserRole> Users { get; set; }


}