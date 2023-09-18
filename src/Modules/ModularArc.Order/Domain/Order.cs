using ModularArc.Order.Data;

namespace ModularArc.Order.Domain;

public class Order : BaseEntity
{
    public string OrderName { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
}