using CleanArc.Application.Models.Common;
using CleanArc.Application.Models.Identity;
using CleanArc.SharedKernel.Contracts.Identity;
using Mediator;

namespace CleanArc.Identity.Application.Commands.Role
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
