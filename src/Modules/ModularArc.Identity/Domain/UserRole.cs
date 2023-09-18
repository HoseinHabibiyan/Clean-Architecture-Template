using Microsoft.AspNetCore.Identity;
using ModularArc.Identity.Data;

namespace ModularArc.Identity.Domain;

public class UserRole : IdentityUserRole<int>, IEntity
{
    public User User { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedUserRoleDate { get; set; }

}