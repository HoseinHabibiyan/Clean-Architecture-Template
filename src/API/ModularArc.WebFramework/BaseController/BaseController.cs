using System.Security.Claims;
using ModularArc.WebFramework.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModularArc.Application.Models.Common;
using ModularArc.Application.Models.Identity;
using ModularArc.SharedKernel.Extensions;

namespace ModularArc.WebFramework.BaseController;

[ApiController]
[Authorize(ConstantPolicies.DynamicPermission)]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseController : ControllerBase
{
    protected string UserName => User.Identity?.Name;
    protected int UserId => int.Parse(User.Identity.GetUserId());
    protected string UserEmail => User.Identity.FindFirstValue(ClaimTypes.Email);
    protected string UserRole => User.Identity.FindFirstValue(ClaimTypes.Role);

    protected string UserKey => User.FindFirstValue(ClaimTypes.UserData);

    //public UserRepository UserRepository { get; set; } => property injection
    protected void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
    }

    protected IActionResult OperationResult<TModel>(OperationResult<TModel> result)
    {
        if (result is null)
            return new ServerErrorResult("Server Error");


        if (result.IsSuccess) return result.Result is bool ? Ok() : Ok(result.Result);

        if (result.IsNotFound)
        {

            ModelState.AddModelError("GeneralError", result.ErrorMessage);

            var notFoundErrors = new ValidationProblemDetails(ModelState);

            return NotFound(notFoundErrors.Errors);
        }

        ModelState.AddModelError("GeneralError", result.ErrorMessage);

        var badRequestErrors = new ValidationProblemDetails(ModelState);

        return BadRequest(badRequestErrors.Errors);

    }
}