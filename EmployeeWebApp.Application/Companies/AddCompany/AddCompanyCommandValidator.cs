using FluentValidation;

namespace EmployeeWebApp.Application.Companies.AddCompany;

/// <summary>
/// Валидатор для <see cref="AddCompanyCommand"/>.
/// </summary>
public class AddCompanyCommandValidator : AbstractValidator<AddCompanyCommand>
{
    public AddCompanyCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
    }
}