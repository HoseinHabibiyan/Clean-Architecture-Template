using ModularArc.Application.Models.Jwt;
using ModularArc.Identity.Domain;
using System.Security.Claims;

namespace ModularArc.Identity.Infrastructure.Jwt;

public interface IJwtService
{
    Task<AccessToken> GenerateAsync(User user);
    Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    Task<AccessToken> GenerateByPhoneNumberAsync(string phoneNumber);
    Task<AccessToken> RefreshToken(Guid refreshTokenId);
}