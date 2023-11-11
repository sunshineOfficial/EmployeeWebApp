using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace EmployeeWebApp.Application.Departments.UpdateDepartment;

/// <summary>
/// Обработчик команды <see cref="UpdateDepartmentCommand"/>.
/// </summary>
public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IValidator<UpdateDepartmentCommand> _validator;

    public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IValidator<UpdateDepartmentCommand> validator)
    {
        _departmentRepository = departmentRepository;
        _validator = validator;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="UpdateDepartmentCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="UpdateDepartmentCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidationException(validationResult.ToString());
        }
        
        if (!await _departmentRepository.DepartmentExistsAsync(request.Id))
        {
            throw new DepartmentNotFoundException(request.Id);
        }
        
        var department = new Department { Name = request.Name, Phone = request.Phone };

        await _departmentRepository.UpdateDepartmentAsync(request.Id, department);
    }
}