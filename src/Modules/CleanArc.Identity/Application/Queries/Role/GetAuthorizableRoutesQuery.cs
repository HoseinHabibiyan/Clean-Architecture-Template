using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Identity.Application.Queries.Role;

public record GetAuthorizableRoutesQuery() : IRequest<OperationResult<List<GetAuthorizableRoutesQueryResponse>>>;