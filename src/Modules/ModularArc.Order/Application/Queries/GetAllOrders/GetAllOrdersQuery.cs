using Mediator;
using ModularArc.Application.Models.Common;

namespace ModularArc.Order.Application.Queries.GetAllOrders;

public record GetAllOrdersQuery() : IRequest<OperationResult<List<GetAllOrdersQueryResponse>>>;