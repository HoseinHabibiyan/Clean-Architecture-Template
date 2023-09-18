using Microsoft.AspNetCore.Identity;
using ModularArc.Identity.Data;

namespace ModularArc.Identity.Domain;

public class UserLogin : IdentityUserLogin<int>, IEntity
{
    public UserLogin()
    {
        LoggedOn = DateTime.Now;
    }

    public User User { get; set; }
    public DateTime LoggedOn { get; set; }
}