using CleanArc.Application.Models.Jwt;
using CleanArc.Identity.Domain;
using System.Security.Claims;

namespace CleanArc.Identity.Infrastructure.Jwt;

public interface IJwtService
{
	Task<AccessToken> GenerateAsync(User user);
	Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
	Task<AccessToken> GenerateByPhoneNumberAsync(string phoneNumber);
	Task<AccessToken> RefreshToken(Guid refreshTokenId);
}