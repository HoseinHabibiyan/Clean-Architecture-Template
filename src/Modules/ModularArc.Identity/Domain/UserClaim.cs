using Microsoft.AspNetCore.Identity;
using ModularArc.Identity.Data;

namespace ModularArc.Identity.Domain;

public class UserClaim : IdentityUserClaim<int>, IEntity
{
    public User User { get; set; }
}