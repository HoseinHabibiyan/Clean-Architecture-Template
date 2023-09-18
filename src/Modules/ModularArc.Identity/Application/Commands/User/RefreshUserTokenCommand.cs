using FluentValidation;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.Application.Models.Jwt;
using ModularArc.SharedKernel.ValidationBase;
using ModularArc.SharedKernel.ValidationBase.Contracts;

namespace ModularArc.Identity.Application.Commands.User;

public record RefreshUserTokenCommand(Guid RefreshToken) : IRequest<OperationResult<AccessToken>>,
    IValidatableModel<RefreshUserTokenCommand>
{
    public IValidator<RefreshUserTokenCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<RefreshUserTokenCommand> validator)
    {
        validator.RuleFor(c => c.RefreshToken)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter valid user refresh token");

        return validator;
    }
};