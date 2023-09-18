using Mediator;
using ModularArc.Application.Models.Common;

namespace ModularArc.Identity.Application.Queries.Role;

public record GetAllRolesQuery() : IRequest<OperationResult<List<GetAllRolesQueryResponse>>>;