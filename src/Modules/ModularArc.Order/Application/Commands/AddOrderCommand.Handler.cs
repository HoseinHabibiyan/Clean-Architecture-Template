using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.Order.Data;
using ModularArc.SharedKernel.Contracts.Identity;

namespace ModularArc.Order.Application.Commands;

internal class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OperationResult<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppUserManager _userManager;

    public AddOrderCommandHandler(IAppUserManager userManager, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<OperationResult<bool>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserByIdAsync(request.UserId);

        if (user == null)
            return OperationResult<bool>.FailureResult("User Not Found");

        await _unitOfWork.OrderRepository.AddOrderAsync(new Domain.Order()
        { UserId = user.Id, OrderName = request.OrderName });

        await _unitOfWork.CommitAsync();

        return OperationResult<bool>.SuccessResult(true);
    }
}