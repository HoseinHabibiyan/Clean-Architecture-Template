using System.Text.Json.Serialization;
using FluentValidation;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.SharedKernel.ValidationBase;
using ModularArc.SharedKernel.ValidationBase.Contracts;

namespace ModularArc.Order.Application.Commands;

public record AddOrderCommand(string OrderName) : IRequest<OperationResult<bool>>,
    IValidatableModel<AddOrderCommand>
{
    [JsonIgnore]
    public int UserId { get; set; }

    public IValidator<AddOrderCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddOrderCommand> validator)
    {
        validator.RuleFor(c => c.OrderName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter your role name");

        return validator;
    }
}