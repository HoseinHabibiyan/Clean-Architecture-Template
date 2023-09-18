using Microsoft.EntityFrameworkCore;

namespace ModularArc.SharedKernel.Contracts.Persistence;
public interface IPersistanceProvider
{
    DbContext PersistanceContext { get; }

}
