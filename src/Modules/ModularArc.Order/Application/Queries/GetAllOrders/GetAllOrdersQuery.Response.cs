namespace ModularArc.Order.Application.Queries.GetAllOrders;

public record GetAllOrdersQueryResponse(int OrderId, string OrderName, int OrderOwnerId, string OrderOwnerUserName);