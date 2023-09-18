using ModularArc.Application.Models.Identity;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.SharedKernel.Contracts.Identity;

namespace ModularArc.Identity.Application.Commands.Role
{
    internal class UpdateRoleClaimsCommandHandler : IRequestHandler<UpdateRoleClaimsCommand, OperationResult<bool>>
    {
        private readonly IRoleManagerService _roleManagerService;

        public UpdateRoleClaimsCommandHandler(IRoleManagerService roleManagerService)
        {
            _roleManagerService = roleManagerService;
        }

        public async ValueTask<OperationResult<bool>> Handle(UpdateRoleClaimsCommand request, CancellationToken cancellationToken)
        {
            var updateRoleResult = await _roleManagerService.ChangeRolePermissionsAsync(request.RoleId, request.RoleClaimValue);

            return updateRoleResult
                ? OperationResult<bool>.SuccessResult(true)
                : OperationResult<bool>.FailureResult("Could Not Update Claims for given Role");
        }
    }
}
