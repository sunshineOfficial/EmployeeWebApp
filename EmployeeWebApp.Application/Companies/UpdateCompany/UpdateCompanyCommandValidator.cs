using FluentValidation;

namespace EmployeeWebApp.Application.Companies.UpdateCompany;

/// <summary>
/// Валидатор для <see cref="UpdateCompanyCommand"/>.
/// </summary>
public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
    }
}