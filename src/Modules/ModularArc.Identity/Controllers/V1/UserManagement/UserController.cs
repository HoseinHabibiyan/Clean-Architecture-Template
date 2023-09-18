using ModularArc.WebFramework.Swagger;
using Mediator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModularArc.Identity.Application.Commands.User;
using ModularArc.Identity.Application.Queries.User;
using ModularArc.WebFramework.BaseController;

namespace ModularArc.Identity.Controllers.V1.UserManagement;

[ApiVersion("1")]
public class UserController : BaseController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> CreateUser(UserCreateCommand model)
    {
        var command = await _mediator.Send(model);

        return OperationResult(command);
    }

    //[HttpPost("ConfirmPhoneNumber")]
    //public async Task<IActionResult> ConfirmPhoneNumber(ConfirmUserPhoneNumberViewModel model)
    //{
    //    var command = await _mediator.Send(new ConfirmPhoneNumberCommand(model.UserKey, model.Code));

    //    return OperationResult(command);
    //}

    [HttpPost("TokenRequest")]
    public async Task<IActionResult> TokenRequest(UserTokenRequestQuery model)
    {
        var query = await _mediator.Send(model);

        return OperationResult(query);
    }

    [HttpPost("LoginConfirmation")]
    public async Task<IActionResult> ValidateUser(GenerateUserTokenQuery model)
    {
        var result = await _mediator.Send(model);

        return OperationResult(result);
    }

    [HttpPost("RefreshSignIn")]
    [RequireTokenWithoutAuthorization]
    public async Task<IActionResult> RefreshUserToken(RefreshUserTokenCommand model)
    {
        var checkCurrentAccessTokenValidity = await HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);

        if (checkCurrentAccessTokenValidity.Succeeded)
            return BadRequest("Current access token is valid. No need to refresh");

        var newTokenResult = await _mediator.Send(model);

        return OperationResult(newTokenResult);
    }

    [HttpPost("Logout")]
    [Authorize]
    public async Task<IActionResult> RequestLogout()
    {
        var commandResult = await _mediator.Send(new RequestLogoutCommand(UserId));

        return OperationResult(commandResult);
    }
}