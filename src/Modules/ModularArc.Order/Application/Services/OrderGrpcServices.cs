using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using ModularArc.Order.Application.Queries.GetUserOrders;
using ModularArc.Order.ProtoModels;
using ModularArc.SharedKernel.Extensions;

namespace ModularArc.Order.Application.Services
{
    [Authorize]
    public class OrderGrpcServices : OrderServices.OrderServicesBase
    {


        private readonly ISender _sender;

        public OrderGrpcServices(ISender sender)
        {
            _sender = sender;
        }

        public override async Task GetUserOrders(Empty request, IServerStreamWriter<GetUserOrdersModel> responseStream, ServerCallContext context)
        {
            var userId = int.Parse(context.GetHttpContext().User.Identity.GetUserId());

            var query = await _sender.Send(new GetUserOrdersQuery(userId));

            if (!query.IsSuccess)
            {
                context.Status = new Status(StatusCode.InvalidArgument, query.ErrorMessage);
                return;
            }

            foreach (var getUsersQueryResultModel in query.Result)
            {
                await responseStream.WriteAsync(new GetUserOrdersModel()
                { OrderId = getUsersQueryResultModel.OrderId, OrderName = getUsersQueryResultModel.OrderName });

                await Task.Delay(400);

            }

        }
    }
}
