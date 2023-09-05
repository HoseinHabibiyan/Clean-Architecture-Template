using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Order.Application.Queries.GetUserOrders;

public record GetUserOrdersQuery(int UserId) : IRequest<OperationResult<List<GetUserOrdersQueryResponse>>>;