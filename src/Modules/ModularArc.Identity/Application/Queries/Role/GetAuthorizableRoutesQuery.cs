using Mediator;
using ModularArc.Application.Models.Common;

namespace ModularArc.Identity.Application.Queries.Role;

public record GetAuthorizableRoutesQuery() : IRequest<OperationResult<List<GetAuthorizableRoutesQueryResponse>>>;