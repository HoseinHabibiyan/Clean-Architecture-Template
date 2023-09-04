namespace CleanArc.Order.Application.Queries.GetAllOrders;

public record GetAllOrdersQueryResult(int OrderId, string OrderName, int OrderOwnerId, string OrderOwnerUserName);