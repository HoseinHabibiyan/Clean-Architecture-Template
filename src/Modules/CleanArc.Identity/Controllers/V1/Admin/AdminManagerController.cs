﻿using CleanArc.Identity.Application.Commands.Admin;
using CleanArc.Identity.Application.Queries.Admin;
using CleanArc.WebFramework.BaseController;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArc.Identity.Controllers.V1.Admin
{
    [ApiVersion("1")]
	[ApiController]
	public class AdminManagerController : BaseController
	{
		private readonly ISender _sender;

		public AdminManagerController(ISender sender)
		{
			_sender = sender;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> AdminLogin(AdminGetTokenQuery model)
		{
			var query = await _sender.Send(model);

			return base.OperationResult(query);
		}

		[Authorize(Roles = "admin")]
		[HttpPost("NewAdmin")]
		public async Task<IActionResult> AddNewAdmin(AddAdminCommand model)
		{
			var commandResult = await _sender.Send(model);

			return OperationResult(commandResult);
		}
	}
}
