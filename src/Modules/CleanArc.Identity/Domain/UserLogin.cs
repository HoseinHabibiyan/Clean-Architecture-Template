using CleanArc.WebFramework.Base;
using Microsoft.AspNetCore.Identity;

namespace CleanArc.Identity.Domain;

public class UserLogin : IdentityUserLogin<int>, IEntity
{
	public UserLogin()
	{
		LoggedOn = DateTime.Now;
	}

	public User User { get; set; }
	public DateTime LoggedOn { get; set; }
}