﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using CleanArc.Application.Features.Order.Queries.GetAllOrders;
using CleanArc.WebFramework.BaseController;
using Mediator;

namespace CleanArc.Web.Api.Controllers.V1.Admin
{
	[ApiVersion("1")]
    [Display(Description= "Managing Users related Orders")]
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
