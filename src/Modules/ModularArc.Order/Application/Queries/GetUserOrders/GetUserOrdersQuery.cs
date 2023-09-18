using Mediator;
using ModularArc.Application.Models.Common;

namespace ModularArc.Order.Application.Queries.GetUserOrders;

public record GetUserOrdersQuery(int UserId) : IRequest<OperationResult<List<GetUserOrdersQueryResponse>>>;