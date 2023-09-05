using CleanArc.Application.Models.Common;
using CleanArc.SharedKernel.Contracts.Identity;
using Mapster;
using Mediator;

namespace CleanArc.Identity.Application.Queries.Role
{
	internal class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, OperationResult<List<GetAllRolesQueryResponse>>>
    {
        private readonly IRoleManagerService _roleManagerService;

        public GetAllRolesQueryHandler(IRoleManagerService roleManagerService)
        {
            _roleManagerService = roleManagerService;
        }

        public async ValueTask<OperationResult<List<GetAllRolesQueryResponse>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleManagerService.GetRolesAsync();

            if (!roles.Any())
                return OperationResult<List<GetAllRolesQueryResponse>>.NotFoundResult("No Roles Found");

            var result = roles.Adapt<List<GetAllRolesQueryResponse>>();

            return OperationResult<List<GetAllRolesQueryResponse>>.SuccessResult(result);
        }
    }
}
