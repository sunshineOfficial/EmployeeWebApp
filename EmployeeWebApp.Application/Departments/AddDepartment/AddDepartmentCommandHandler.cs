using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace EmployeeWebApp.Application.Departments.AddDepartment;

/// <summary>
/// Обработчик команды <see cref="AddDepartmentCommand"/>.
/// </summary>
public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, int>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IValidator<AddDepartmentCommand> _validator;

    public AddDepartmentCommandHandler(IDepartmentRepository departmentRepository, IValidator<AddDepartmentCommand> validator)
    {
        _departmentRepository = departmentRepository;
        _validator = validator;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="AddDepartmentCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="AddDepartmentCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Id отдела.</returns>
    public async Task<int> Handle(AddDepartmentCommand request, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidationException(validationResult.ToString());
        }
        
        var department = new Department { Name = request.Name, Phone = request.Phone };

        return await _departmentRepository.AddDepartmentAsync(department);
    }
}