using Mediator;
using ModularArc.Application.Models.Common;

namespace ModularArc.Identity.Application.Queries.User;

public record GetUsersQuery : IRequest<OperationResult<List<GetUsersQueryResponse>>>;