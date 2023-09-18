namespace ModularArc.Order.Application.Repositories;

public interface IOrderRepository
{
    Task AddOrderAsync(Domain.Order order);
    Task<List<Domain.Order>> GetAllUserOrdersAsync(int userId);
    Task<List<Domain.Order>> GetAllOrdersWithRelatedUserAsync();
}