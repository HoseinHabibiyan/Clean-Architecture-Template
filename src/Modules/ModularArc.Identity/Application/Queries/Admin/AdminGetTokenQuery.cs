using FluentValidation;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.Application.Models.Jwt;
using ModularArc.SharedKernel.ValidationBase;
using ModularArc.SharedKernel.ValidationBase.Contracts;

namespace ModularArc.Identity.Application.Queries.Admin;

public record AdminGetTokenQuery(string UserName, string Password) : IRequest<OperationResult<AccessToken>>,
    IValidatableModel<AdminGetTokenQuery>
{
    public IValidator<AdminGetTokenQuery> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AdminGetTokenQuery> validator)
    {
        validator.RuleFor(c => c.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter admin username");

        validator.RuleFor(c => c.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please enter admin password");

        return validator;
    }
};