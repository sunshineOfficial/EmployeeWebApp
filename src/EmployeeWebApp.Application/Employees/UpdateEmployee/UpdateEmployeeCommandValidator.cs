using FluentValidation;

namespace EmployeeWebApp.Application.Employees.UpdateEmployee;

/// <summary>
/// Валидатор для <see cref="UpdateEmployeeCommand"/>.
/// </summary>
public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50)
            .When(x => x.Name != null);
        
        RuleFor(x => x.Surname)
            .NotEmpty()
            .MaximumLength(50)
            .When(x => x.Surname != null);
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$")
            .When(x => x.Phone != null);
    }
}