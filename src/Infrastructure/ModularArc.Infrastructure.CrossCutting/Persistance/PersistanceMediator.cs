using Mapster;
using ModularArc.SharedKernel.Contracts.Persistence;
using System.Transactions;

namespace ModularArc.Infrastructure.CrossCutting.Persistance;
public class PersistanceMediator
{
    private readonly IEnumerable<IPersistanceProvider> _persistanceProviders;

    public PersistanceMediator(IEnumerable<IPersistanceProvider> persistanceProviders)
    {
        _persistanceProviders = persistanceProviders;
    }

    public async Task<int> CommitChangesAsync(CancellationToken cancellationToken)
    {
        if (!_persistanceProviders.Any())
            return 0;

        int affectedRow = 0;

        using var transactionScope = _persistanceProviders.First().PersistanceContext.Database.BeginTransaction();

        await transactionScope.CreateSavepointAsync("RoleBack");

        try
        {
            foreach (var provider in _persistanceProviders)
            {
                affectedRow += await provider.PersistanceContext.SaveChangesAsync(cancellationToken);
            }
        }
        catch (Exception e)
        {
            await transactionScope.RollbackToSavepointAsync("RoleBack", cancellationToken);
            throw;
        }
        finally
        {
            await transactionScope.CommitAsync(cancellationToken);
        }

        return affectedRow;
    }

    public async Task<TSource> CommitChangesAsync<TSource>(CancellationToken cancellationToken)
    {
        if (!_persistanceProviders.Any())
            return default;

        using var transactionScope = _persistanceProviders.First().PersistanceContext.Database.BeginTransaction();

        await transactionScope.CreateSavepointAsync("RoleBack");

        var config = new TypeAdapterConfig();
        config.RequireDestinationMemberSource = true;

        try
        {
            TSource source = default;
            foreach (var provider in _persistanceProviders)
            {
                await provider.PersistanceContext.SaveChangesAsync(cancellationToken);
                var entries = provider.PersistanceContext.ChangeTracker.Entries();

                foreach (var entry in entries)
                {

                    try
                    {
                        source = entry.Entity.Adapt<TSource>(config);
                    }
                    catch (Exception e)
                    {
                        continue;
                    }

                }
            }

            return source;
        }
        catch (Exception e)
        {
            await transactionScope.RollbackToSavepointAsync("RoleBack", cancellationToken);
            throw;
        }
        finally
        {
            await transactionScope.CommitAsync(cancellationToken);
        }

    }
}

