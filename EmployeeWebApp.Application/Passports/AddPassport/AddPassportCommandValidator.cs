using FluentValidation;

namespace EmployeeWebApp.Application.Passports.AddPassport;

/// <summary>
/// Валидатор для <see cref="AddPassportCommand"/>.
/// </summary>
public class AddPassportCommandValidator : AbstractValidator<AddPassportCommand>
{
    public AddPassportCommandValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty();

        RuleFor(x => x.Number)
            .NotEmpty();
    }
}