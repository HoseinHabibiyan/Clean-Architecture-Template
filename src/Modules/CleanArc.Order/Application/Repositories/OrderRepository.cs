using CleanArc.Infrastructure.CrossCutting.Persistance;
using CleanArc.Order.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArc.Order.Application.Repositories;

internal class OrderRepository : BaseAsyncRepository<Domain.Order>, IOrderRepository
{
    public OrderRepository(OrderDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddOrderAsync(Domain.Order order)
    {
        await base.AddAsync(order);
    }

    public async Task<List<Domain.Order>> GetAllUserOrdersAsync(int userId)
    {
        return await base.TableNoTracking.Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<List<Domain.Order>> GetAllOrdersWithRelatedUserAsync()
    {
        var orders = await base.TableNoTracking.Include(c => c.User).ToListAsync();

        return orders;
    }
}