using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Identity.Application.Queries.User;

public record GetUsersQuery : IRequest<OperationResult<List<GetUsersQueryResponse>>>;