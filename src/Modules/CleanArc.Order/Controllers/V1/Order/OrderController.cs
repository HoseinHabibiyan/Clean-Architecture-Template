using CleanArc.Order.Application.Commands;
using CleanArc.Order.Application.Queries.GetUserOrders;
using CleanArc.WebFramework.BaseController;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArc.Order.Controllers.V1.Order;

[ApiVersion("1")]
[Authorize]
public class OrderController : BaseController
{
	private readonly ISender _sender;

	public OrderController(ISender sender)
	{
		_sender = sender;
	}

	[HttpPost("CreateNewOrder")]
	public async Task<IActionResult> CreateNewOrder(AddOrderCommand model)
	{
		model.UserId = UserId;
		var command = await _sender.Send(model);

		return OperationResult(command);
	}

	[HttpGet("GetUserOrders")]
	public async Task<IActionResult> GetUserOrders()
	{
		var query = await _sender.Send(new GetUserOrdersQuery(UserId));

		return OperationResult(query);
	}
}