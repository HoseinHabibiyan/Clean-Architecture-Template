using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.SharedKernel.Contracts.Identity;

namespace ModularArc.Identity.Application.Commands.User
{
    internal class RequestLogoutCommandHandler : IRequestHandler<RequestLogoutCommand, OperationResult<bool>>
    {
        private readonly IAppUserManager _userManager;

        public RequestLogoutCommandHandler(IAppUserManager userManager)
        {
            _userManager = userManager;
        }

        public async ValueTask<OperationResult<bool>> Handle(RequestLogoutCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserByIdAsync(request.UserId);

            if (user == null)
                return OperationResult<bool>.FailureResult("User not found");

            await _userManager.UpdateSecurityStampAsync(user);

            return OperationResult<bool>.SuccessResult(true);
        }
    }
}
