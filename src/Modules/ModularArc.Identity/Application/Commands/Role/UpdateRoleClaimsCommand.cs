using Mediator;
using ModularArc.Application.Models.Common;

namespace ModularArc.Identity.Application.Commands.Role;

public record UpdateRoleClaimsCommand(int RoleId, List<string> RoleClaimValue) : IRequest<OperationResult<bool>>;