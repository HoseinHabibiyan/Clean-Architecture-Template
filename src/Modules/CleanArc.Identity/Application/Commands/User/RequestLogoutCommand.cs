using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Identity.Application.Commands.User;

public record RequestLogoutCommand(int UserId) : IRequest<OperationResult<bool>>;