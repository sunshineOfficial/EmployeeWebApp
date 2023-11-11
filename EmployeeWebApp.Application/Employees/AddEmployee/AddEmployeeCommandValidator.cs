using FluentValidation;

namespace EmployeeWebApp.Application.Employees.AddEmployee;

/// <summary>
/// Валидатор для <see cref="AddEmployeeCommand"/>.
/// </summary>
public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
{
    public AddEmployeeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.Surname)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");
    }
}