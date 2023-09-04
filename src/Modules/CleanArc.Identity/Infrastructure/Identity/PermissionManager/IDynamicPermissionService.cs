using System.Security.Claims;

namespace CleanArc.Identity.Infrastructure.Identity.PermissionManager;

public interface IDynamicPermissionService
{
	bool CanAccess(ClaimsPrincipal user, string area, string controller, string action);
}