using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace EmployeeWebApp.Application.Employees.UpdateEmployee;

/// <summary>
/// Обработчик команды <see cref="UpdateEmployeeCommand"/>.
/// </summary>
public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IValidator<UpdateEmployeeCommand> _validator;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IValidator<UpdateEmployeeCommand> validator)
    {
        _employeeRepository = employeeRepository;
        _validator = validator;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="UpdateEmployeeCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="UpdateEmployeeCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidationException(validationResult.ToString());
        }
        
        if (!await _employeeRepository.EmployeeExistsAsync(request.Id))
        {
            throw new EmployeeNotFoundException(request.Id);
        }
        
        var employee = new Employee
        {
            Name = request.Name,
            Surname = request.Surname,
            Phone = request.Phone,
            CompanyId = request.CompanyId,
            PassportId = request.PassportId,
            DepartmentId = request.DepartmentId
        };

        await _employeeRepository.UpdateEmployeeAsync(request.Id, employee);
    }
}