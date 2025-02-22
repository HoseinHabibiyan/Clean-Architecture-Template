﻿using ModularArc.Application.Models.Identity;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.SharedKernel.Contracts.Identity;

namespace ModularArc.Identity.Application.Commands.Role
{
    internal class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, OperationResult<bool>>
    {
        private readonly IRoleManagerService _roleManagerService;

        public AddRoleCommandHandler(IRoleManagerService roleManagerService)
        {
            _roleManagerService = roleManagerService;
        }

        public async ValueTask<OperationResult<bool>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var addRoleResult =
                await _roleManagerService.CreateRoleAsync(request.RoleName);

            if (addRoleResult.Succeeded)
                return OperationResult<bool>.SuccessResult(true);

            var errors = string.Join("\n", addRoleResult.Errors.Select(c => c.Description));

            return OperationResult<bool>.FailureResult(errors);
        }
    }
}
