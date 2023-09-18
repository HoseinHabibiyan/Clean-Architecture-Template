using Microsoft.AspNetCore.Identity;
using ModularArc.Identity.Data;

namespace ModularArc.Identity.Domain;

public class UserToken : IdentityUserToken<int>, IEntity
{
    public UserToken()
    {
        GeneratedTime = DateTime.Now;
    }

    public User User { get; set; }
    public DateTime GeneratedTime { get; set; }

}