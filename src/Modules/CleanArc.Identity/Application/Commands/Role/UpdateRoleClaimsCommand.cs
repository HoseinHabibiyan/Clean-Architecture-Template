using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Identity.Application.Commands.Role;

public record UpdateRoleClaimsCommand(int RoleId, List<string> RoleClaimValue) : IRequest<OperationResult<bool>>;