using CleanArc.Application.Models.Common;
using CleanArc.Identity.Infrastructure.UserManager;
using CleanArc.SharedKernel.Contracts.Identity;
using CleanArc.SharedKernel.Extensions;
using Mediator;

namespace CleanArc.Identity.Application.Commands.Admin
{
	internal class AddAdminCommandHandler : IRequestHandler<AddAdminCommand, OperationResult<bool>>
    {
        private readonly IAppUserManager _userManager;
        private readonly IRoleManagerService _roleManagerService;

        public AddAdminCommandHandler(IAppUserManager userManager, IRoleManagerService roleManagerService)
        {
            _userManager = userManager;
            _roleManagerService = roleManagerService;
        }

        public async ValueTask<OperationResult<bool>> Handle(AddAdminCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleManagerService.GetRoleByIdAsync(request.RoleId);

            if (role is null)
                return OperationResult<bool>.NotFoundResult("Specified role not found");

            var newAdmin = new Domain.User { UserName = request.UserName, Email = request.Email };

            var adminCreateResult =
                await _userManager.CreateUserWithPasswordAsync(
                    newAdmin, request.Password);

            if (!adminCreateResult.Succeeded)
                return OperationResult<bool>.FailureResult(adminCreateResult.Errors.StringifyIdentityResultErrors());

            var addAdminToRoleResult = await _userManager.AddUserToRoleAsync(newAdmin, role);

            if (addAdminToRoleResult.Succeeded)
                return OperationResult<bool>.SuccessResult(true);

            return OperationResult<bool>.FailureResult(addAdminToRoleResult.Errors.StringifyIdentityResultErrors());
        }
    }
}
