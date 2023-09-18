using Microsoft.AspNetCore.Identity;
using ModularArc.Identity.Data;

namespace ModularArc.Identity.Domain;

public class RoleClaim : IdentityRoleClaim<int>, IEntity
{
    public RoleClaim()
    {
        CreatedClaim = DateTime.Now;
    }

    public DateTime CreatedClaim { get; set; }
    public Role Role { get; set; }

}