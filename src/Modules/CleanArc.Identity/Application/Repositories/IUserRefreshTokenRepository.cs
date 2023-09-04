using CleanArc.Identity.Domain;
using CleanArc.SharedKernel.Dto.Identity;

namespace CleanArc.Identity.Application.Repositories;

public interface IUserRefreshTokenRepository
{
	Task<Guid> CreateToken(int userId);
	Task<UserRefreshToken> GetTokenWithInvalidation(Guid id);
	Task<User> GetUserByRefreshToken(Guid tokenId);
	Task RemoveUserOldTokens(int userId, CancellationToken cancellationToken);
}