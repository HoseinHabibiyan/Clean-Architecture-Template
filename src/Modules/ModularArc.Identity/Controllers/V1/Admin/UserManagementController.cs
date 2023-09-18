using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Mediator;
using ModularArc.Identity.Application.Queries.User;
using ModularArc.WebFramework.BaseController;

namespace ModularArc.Identity.Controllers.V1.Admin
{
    [ApiVersion("1")]
    [Display(Description = "Managing API Users")]
    public class UserManagementController : BaseController
    {
        private readonly ISender _sender;

        public UserManagementController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("CurrentUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var queryResult = await _sender.Send(new GetUsersQuery());

            return OperationResult(queryResult);
        }
    }
}
