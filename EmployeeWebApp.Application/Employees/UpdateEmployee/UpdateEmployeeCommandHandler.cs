using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Employees.UpdateEmployee;

/// <summary>
/// Обработчик команды <see cref="UpdateEmployeeCommand"/>.
/// </summary>
public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="UpdateEmployeeCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="UpdateEmployeeCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken = default)
    {
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