using FluentValidation;
using ModularArc.SharedKernel.ValidationBase;

namespace ModularArc.SharedKernel.ValidationBase.Contracts;

public interface IValidatableModel<TApplicationModel> where TApplicationModel : class
{
    IValidator<TApplicationModel> ValidateApplicationModel(ApplicationBaseValidationModelProvider<TApplicationModel> validator);
}