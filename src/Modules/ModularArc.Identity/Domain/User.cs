using Microsoft.AspNetCore.Identity;
using ModularArc.Identity.Data;

namespace ModularArc.Identity.Domain;

public class User : IdentityUser<int>, IEntity
{
    public User()
    {
        GeneratedCode = Guid.NewGuid().ToString().Substring(0, 8);
    }

    public string Name { get; set; }
    public string FamilyName { get; set; }
    public string GeneratedCode { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<UserLogin> Logins { get; set; }
    public ICollection<UserClaim> Claims { get; set; }
    public ICollection<UserToken> Tokens { get; set; }
    public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
}