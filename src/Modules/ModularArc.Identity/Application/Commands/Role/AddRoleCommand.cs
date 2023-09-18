using FluentValidation;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.SharedKernel.ValidationBase;
using ModularArc.SharedKernel.ValidationBase.Contracts;

namespace ModularArc.Identity.Application.Commands.Role;

public record AddRoleCommand(string RoleName) : IRequest<OperationResult<bool>>,
    IValidatableModel<AddRoleCommand>
{
    public IValidator<AddRoleCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddRoleCommand> validator)
    {
        validator
            .RuleFor(c => c.RoleName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter role name");

        return validator;
    }
};