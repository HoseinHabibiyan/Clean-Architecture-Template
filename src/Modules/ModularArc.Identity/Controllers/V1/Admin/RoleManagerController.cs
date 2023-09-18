using System.ComponentModel.DataAnnotations;
using ModularArc.Identity.Application.Queries.Role;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using ModularArc.Identity.Application.Commands.Role;
using ModularArc.WebFramework.BaseController;

namespace ModularArc.Identity.Controllers.V1.Admin
{
    [ApiVersion("1")]
    [Display(Description = "Managing Related Roles for the System")]

    public class RoleManagerController : BaseController
    {
        private readonly ISender _sender;

        public RoleManagerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var queryResult = await _sender.Send(new GetAllRolesQuery());

            return OperationResult(queryResult);
        }

        [HttpGet("AuthRoutes")]
        public async Task<IActionResult> GetAuthRoutes()
        {
            var queryModel = await _sender.Send(new GetAuthorizableRoutesQuery());

            return base.OperationResult(queryModel);
        }

        /// <summary>
        /// Update a role permissions (claims) based on RouteKey received in AuthRoutes API
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateRolePermissions")]
        public async Task<IActionResult> UpdateRolePermissions(UpdateRoleClaimsCommand model)
        {
            var commandResult =
                await _sender.Send(new UpdateRoleClaimsCommand(model.RoleId, model.RoleClaimValue));

            return OperationResult(commandResult);
        }

        [HttpPost("NewRole")]
        public async Task<IActionResult> AddRole(AddRoleCommand model)
        {
            var commandResult = await _sender.Send(model);

            return OperationResult(commandResult);
        }

    }
}
