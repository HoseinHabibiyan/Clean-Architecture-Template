using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Mediator;
using ModularArc.Order.Application.Queries.GetAllOrders;
using ModularArc.WebFramework.BaseController;

namespace ModularArc.Order.Controllers.V1.Admin
{
    [ApiVersion("1")]
    [Display(Description = "Managing Users related Orders")]
    public class OrderManagementController : BaseController
    {
        private readonly ISender _sender;

        public OrderManagementController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("OrderList")]
        public async Task<IActionResult> GetOrders()
        {
            var queryResult = await _sender.Send(new GetAllOrdersQuery());

            return base.OperationResult(queryResult);
        }
    }
}
