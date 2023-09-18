using AutoMapper;
using Mapster;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.SharedKernel.Contracts.Identity;

namespace ModularArc.Identity.Application.Queries.User;

internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, OperationResult<List<GetUsersQueryResponse>>>
{
    readonly IAppUserManager _userManager;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IAppUserManager userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async ValueTask<OperationResult<List<GetUsersQueryResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var usersModel = await _userManager.GetAllUsersAsync();

        if (!usersModel.Any())
            return OperationResult<List<GetUsersQueryResponse>>.NotFoundResult("No Users Found!");

        return OperationResult<List<GetUsersQueryResponse>>.SuccessResult(usersModel.Adapt<List<GetUsersQueryResponse>>());
    }
}