using CleanArc.Order.Application.Repositories;

namespace CleanArc.Order.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly OrderDbContext _db;

		public IOrderRepository OrderRepository { get; }

		public UnitOfWork(OrderDbContext db)
		{
			_db = db;
			OrderRepository = new OrderRepository(_db);
		}

		public Task CommitAsync()
		{
			return _db.SaveChangesAsync();
		}

		public ValueTask RollBackAsync()
		{
			return _db.DisposeAsync();
		}
	}
}
