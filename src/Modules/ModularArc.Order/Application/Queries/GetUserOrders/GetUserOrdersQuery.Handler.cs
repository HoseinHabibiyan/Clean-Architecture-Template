using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.Order.Application.Repositories;

namespace ModularArc.Order.Application.Queries.GetUserOrders;

internal class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, OperationResult<List<GetUserOrdersQueryResponse>>>
{
    private readonly IOrderRepository _orderRepository;

    public GetUserOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async ValueTask<OperationResult<List<GetUserOrdersQueryResponse>>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllUserOrdersAsync(request.UserId);

        if (!orders.Any())
            return OperationResult<List<GetUserOrdersQueryResponse>>.NotFoundResult("You Don't Have Any Orders");

        var result = orders.Select(c => new GetUserOrdersQueryResponse(c.Id, c.OrderName));

        return OperationResult<List<GetUserOrdersQueryResponse>>.SuccessResult(result.ToList());
    }
}