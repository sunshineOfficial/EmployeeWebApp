using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Employees.AddEmployee;

/// <summary>
/// Обработчик команды <see cref="AddEmployeeCommand"/>.
/// </summary>
public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, int>
{
    private readonly IEmployeeRepository _employeeRepository;

    public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="AddEmployeeCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="AddEmployeeCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Id cотрудника.</returns>
    public async Task<int> Handle(AddEmployeeCommand request, CancellationToken cancellationToken = default)
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

        return await _employeeRepository.AddEmployeeAsync(employee);
    }
}