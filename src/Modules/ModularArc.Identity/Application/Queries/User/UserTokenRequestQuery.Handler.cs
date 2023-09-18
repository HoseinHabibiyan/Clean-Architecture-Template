using Mediator;
using Microsoft.Extensions.Logging;
using ModularArc.Application.Models.Common;
using ModularArc.SharedKernel.Contracts.Identity;

namespace ModularArc.Identity.Application.Queries.User;

public class UserTokenRequestQueryHandler : IRequestHandler<UserTokenRequestQuery, OperationResult<UserTokenRequestQueryResponse>>
{
    private readonly IAppUserManager _userManager;
    private readonly ILogger<UserTokenRequestQueryHandler> _logger;

    public UserTokenRequestQueryHandler(IAppUserManager userManager, ILogger<UserTokenRequestQueryHandler> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }


    public async ValueTask<OperationResult<UserTokenRequestQueryResponse>> Handle(UserTokenRequestQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserByPhoneNumber(request.UserPhoneNumber);

        if (user is null)
            return OperationResult<UserTokenRequestQueryResponse>.NotFoundResult("User Not found");

        var code = user.PhoneNumberConfirmed ? await _userManager.GenerateOtpCode(user) : await _userManager.GeneratePhoneNumberConfirmationToken(user, user.PhoneNumber);

        _logger.LogWarning($"Generated Code for user Id {user.Id} is {code}");

        //TODO Send Code Via Sms Provider

        return OperationResult<UserTokenRequestQueryResponse>.SuccessResult(new UserTokenRequestQueryResponse { UserKey = user.GeneratedCode });
    }
}