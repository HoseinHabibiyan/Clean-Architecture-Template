﻿using FluentValidation;
using Mediator;
using ModularArc.Application.Models.Common;
using ModularArc.SharedKernel.ValidationBase;
using ModularArc.SharedKernel.ValidationBase.Contracts;

namespace ModularArc.Identity.Application.Commands.Admin;

public record AddAdminCommand
    (string UserName, string Email, string Password, int RoleId) : IRequest<OperationResult<bool>>,
        IValidatableModel<AddAdminCommand>
{
    public IValidator<AddAdminCommand> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AddAdminCommand> validator)
    {
        validator.RuleFor(c => c.Email)
            .EmailAddress()
            .WithMessage("Please enter an valid email");

        validator.RuleFor(c => c.UserName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Please specify a valid username");

        validator
            .RuleFor(c => c.RoleId)
            .GreaterThan(0)
            .WithMessage("Please select a valid role");

        return validator;
    }
};