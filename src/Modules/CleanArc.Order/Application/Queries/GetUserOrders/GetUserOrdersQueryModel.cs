using CleanArc.Application.Models.Common;
using Mediator;

namespace CleanArc.Order.Application.Queries.GetUserOrders;

public record GetUserOrdersQueryModel(int UserId) : IRequest<OperationResult<List<GetUsersQueryResultModel>>>;