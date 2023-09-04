using CleanArc.WebFramework.Base;

namespace CleanArc.Order.Domain;

public class Order : BaseEntity
{
	public string OrderName { get; set; }
	public int UserId { get; set; }

}