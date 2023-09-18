using Microsoft.EntityFrameworkCore;
using ModularArc.Order.Data;
using ModularArc.SharedKernel.Contracts.Persistence;

namespace ModularArc.Order.Application.Repositories;

public class OrderRepository : BaseAsyncRepository<Domain.Order>, IOrderRepository, IPersistanceProvider
{
    private readonly OrderDbContext _dbContext;
    public OrderRepository(OrderDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public DbContext PersistanceContext => _dbContext;

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
        var orders = await base.TableNoTracking.ToListAsync();

        return orders;
    }
}