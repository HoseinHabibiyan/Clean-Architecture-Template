using FluentValidation;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.Application.Models.Jwt;
using ModularArc.SharedKernel.ValidationBase;
using ModularArc.SharedKernel.ValidationBase.Contracts;

namespace ModularArc.Identity.Application.Queries.User;

public record GenerateUserTokenQuery(string UserKey, string Code) : IRequest<OperationResult<AccessToken>>,
    IValidatableModel<GenerateUserTokenQuery>
{
    public IValidator<GenerateUserTokenQuery> ValidateApplicationModel(ApplicationBaseValidationModelProvider<GenerateUserTokenQuery> validator)
    {
        validator.RuleFor(c => c.Code)
            .NotEmpty()
            .NotNull()
            .Length(6)
            .WithMessage("User code is not valid");

        validator.RuleFor(c => c.UserKey)
            .NotEmpty()
            .NotNull()
            .WithMessage("Invalid user key");

        return validator;
    }
};