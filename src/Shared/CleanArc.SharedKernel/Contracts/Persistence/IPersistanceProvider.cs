using Microsoft.EntityFrameworkCore;

namespace CleanArc.SharedKernel.Contracts.Persistence;
public interface IPersistanceProvider
{
	DbContext PersistanceContext { get; }

}
