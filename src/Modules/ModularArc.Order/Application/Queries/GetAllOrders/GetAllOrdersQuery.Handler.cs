using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.Order.Data;

namespace ModularArc.Order.Application.Queries.GetAllOrders
{
    internal class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, OperationResult<List<GetAllOrdersQueryResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async ValueTask<OperationResult<List<GetAllOrdersQueryResponse>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.OrderRepository.GetAllOrdersWithRelatedUserAsync();

            var result = orders.Select(c => new GetAllOrdersQueryResponse(c.Id, c.OrderName, c.UserId, c.UserName)).ToList();

            return OperationResult<List<GetAllOrdersQueryResponse>>.SuccessResult(result);
        }
    }
}
