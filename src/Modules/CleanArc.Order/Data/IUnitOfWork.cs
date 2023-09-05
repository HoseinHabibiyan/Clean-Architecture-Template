using CleanArc.Order.Application.Repositories;

namespace CleanArc.Order.Data
{
	public interface IUnitOfWork
	{
		public IOrderRepository OrderRepository { get; }
		Task CommitAsync();
		ValueTask RollBackAsync();
	}
}
