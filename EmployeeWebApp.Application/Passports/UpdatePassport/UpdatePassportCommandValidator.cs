using FluentValidation;

namespace EmployeeWebApp.Application.Passports.UpdatePassport;

/// <summary>
/// Валидатор для <see cref="UpdatePassportCommand"/>.
/// </summary>
public class UpdatePassportCommandValidator : AbstractValidator<UpdatePassportCommand>
{
    public UpdatePassportCommandValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty()
            .When(x => x.Type != null);

        RuleFor(x => x.Number)
            .NotEmpty()
            .When(x => x.Number != null);
    }
}