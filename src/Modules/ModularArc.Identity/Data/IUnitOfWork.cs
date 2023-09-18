using ModularArc.Identity.Application.Repositories;

namespace ModularArc.Identity.Data
{
    public interface IUnitOfWork
    {
        public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
        Task CommitAsync();
        ValueTask RollBackAsync();
    }
}
