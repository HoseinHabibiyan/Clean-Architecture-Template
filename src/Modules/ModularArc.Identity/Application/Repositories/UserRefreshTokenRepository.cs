using Microsoft.EntityFrameworkCore;
using ModularArc.Identity.Data;
using ModularArc.Identity.Domain;
using ModularArc.SharedKernel.Contracts.Persistence;

namespace ModularArc.Identity.Application.Repositories;

public class UserRefreshTokenRepository : BaseAsyncRepository<UserRefreshToken>, IUserRefreshTokenRepository, IPersistanceProvider
{
    private readonly IdentityAppDbContext _dbContext;
    public UserRefreshTokenRepository(IdentityAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public DbContext PersistanceContext => _dbContext;

    public async Task<Guid> CreateToken(int userId)
    {
        var token = new UserRefreshToken { IsValid = true, UserId = userId };
        await base.AddAsync(token);
        return token.Id;
    }

    public async Task<UserRefreshToken> GetTokenWithInvalidation(Guid id)
    {
        var token = await base.Table.Where(t => t.IsValid && t.Id.Equals(id)).FirstOrDefaultAsync();

        return token;
    }

    public async Task<User> GetUserByRefreshToken(Guid tokenId)
    {
        var user = await base.TableNoTracking.Include(t => t.User).Where(c => c.Id.Equals(tokenId))
            .Select(c => c.User).FirstOrDefaultAsync();

        return user;
    }

    public Task RemoveUserOldTokens(int userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}