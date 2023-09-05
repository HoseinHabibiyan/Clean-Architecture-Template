using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Order.Application.Queries.GetAllOrders;

public record GetAllOrdersQuery() : IRequest<OperationResult<List<GetAllOrdersQueryResponse>>>;