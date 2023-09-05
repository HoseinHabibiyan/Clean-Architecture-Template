using CleanArc.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.Identity.Domain;

public class UserToken : IdentityUserToken<int>, IEntity
{
	public UserToken()
	{
		GeneratedTime = DateTime.Now;
	}

	public User User { get; set; }
	public DateTime GeneratedTime { get; set; }

}