using ModularArc.SharedKernel.Dto.Identity;
using ModularArc.Identity.Domain;

namespace ModularArc.Identity.Application.Repositories;

public interface IUserRefreshTokenRepository
{
    Task<Guid> CreateToken(int userId);
    Task<UserRefreshToken> GetTokenWithInvalidation(Guid id);
    Task<User> GetUserByRefreshToken(Guid tokenId);
    Task RemoveUserOldTokens(int userId, CancellationToken cancellationToken);
}