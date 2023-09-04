using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Identity.Application.Queries.Role;

public record GetAllRolesQuery() : IRequest<OperationResult<List<GetAllRolesQueryResponse>>>;