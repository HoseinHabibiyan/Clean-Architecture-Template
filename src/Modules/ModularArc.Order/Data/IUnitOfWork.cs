using ModularArc.Order.Application.Repositories;

namespace ModularArc.Order.Data
{
    public interface IUnitOfWork
    {
        public IOrderRepository OrderRepository { get; }
        Task CommitAsync();
        ValueTask RollBackAsync();
    }
}
