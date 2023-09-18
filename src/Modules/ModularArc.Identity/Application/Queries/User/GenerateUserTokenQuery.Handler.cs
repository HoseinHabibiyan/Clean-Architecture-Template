using Mapster;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.Application.Models.Jwt;
using ModularArc.Identity.Infrastructure.Jwt;
using ModularArc.SharedKernel.Contracts.Identity;
using ModularArc.SharedKernel.Extensions;

namespace ModularArc.Identity.Application.Queries.User;

internal class GenerateUserTokenQueryHandler : IRequestHandler<GenerateUserTokenQuery, OperationResult<AccessToken>>
{
    private readonly IJwtService _jwtService;
    private readonly IAppUserManager _userManager;


    public GenerateUserTokenQueryHandler(IJwtService jwtService, IAppUserManager userManager)
    {
        _jwtService = jwtService;
        _userManager = userManager;
    }

    public async ValueTask<OperationResult<AccessToken>> Handle(GenerateUserTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserByCode(request.UserKey);

        if (user is null)
            return OperationResult<AccessToken>.FailureResult("User Not found");

        var result = user.PhoneNumberConfirmed ? await _userManager.VerifyUserCode(
            user, request.Code) : await _userManager.ChangePhoneNumber(user, user.PhoneNumber, request.Code);


        if (!result.Succeeded)
            return OperationResult<AccessToken>.FailureResult(result.Errors.StringifyIdentityResultErrors());

        await _userManager.UpdateUserAsync(user);

        var token = await _jwtService.GenerateAsync(user.Adapt<Domain.User>());

        return OperationResult<AccessToken>.SuccessResult(token);
    }
}