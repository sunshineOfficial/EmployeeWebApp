using FluentValidation;

namespace EmployeeWebApp.Application.Departments.AddDepartment;

/// <summary>
/// Валидатор для <see cref="AddDepartmentCommand"/>.
/// </summary>
public class AddDepartmentCommandValidator : AbstractValidator<AddDepartmentCommand>
{
    public AddDepartmentCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Phone)
            .NotEmpty()
            .Matches(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");
    }
}