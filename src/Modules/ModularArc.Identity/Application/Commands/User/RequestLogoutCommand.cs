using Mediator;
using ModularArc.Application.Models.Common;

namespace ModularArc.Identity.Application.Commands.User;

public record RequestLogoutCommand(int UserId) : IRequest<OperationResult<bool>>;