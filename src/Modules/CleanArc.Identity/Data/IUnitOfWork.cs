using CleanArc.Identity.Application.Repositories;

namespace CleanArc.Identity.Data
{
	public interface IUnitOfWork
	{
		public IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
		Task CommitAsync();
		ValueTask RollBackAsync();
	}
}
