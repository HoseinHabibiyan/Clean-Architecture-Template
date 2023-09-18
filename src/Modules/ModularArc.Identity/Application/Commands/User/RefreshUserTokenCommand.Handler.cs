using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.Application.Models.Jwt;
using ModularArc.Identity.Infrastructure.Jwt;

namespace ModularArc.Identity.Application.Commands.User
{
    internal class RefreshUserTokenCommandHandler : IRequestHandler<RefreshUserTokenCommand, OperationResult<AccessToken>>
    {
        private readonly IJwtService _jwtService;

        public RefreshUserTokenCommandHandler(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public async ValueTask<OperationResult<AccessToken>> Handle(RefreshUserTokenCommand request, CancellationToken cancellationToken)
        {
            var newToken = await _jwtService.RefreshToken(request.RefreshToken);

            if (newToken is null)
                return OperationResult<AccessToken>.FailureResult("Invalid refresh token");

            return OperationResult<AccessToken>.SuccessResult(newToken);
        }
    }
}
