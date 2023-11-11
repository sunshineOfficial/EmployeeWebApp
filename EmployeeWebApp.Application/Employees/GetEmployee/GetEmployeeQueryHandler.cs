using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Employees.GetEmployee;

/// <summary>
/// Обработчик запроса <see cref="GetEmployeeQuery"/>.
/// </summary>
public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, GetEmployeeResponse>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IPassportRepository _passportRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public GetEmployeeQueryHandler(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IPassportRepository passportRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _companyRepository = companyRepository;
        _passportRepository = passportRepository;
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// Обрабатывает запрос <see cref="GetEmployeeQuery"/>.
    /// </summary>
    /// <param name="request"><see cref="GetEmployeeQuery"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Сотрудник с указанным id.</returns>
    public async Task<GetEmployeeResponse> Handle(GetEmployeeQuery request, CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetEmployeeAsync(request.Id);

        if (employee is null)
        {
            throw new EmployeeNotFoundException(request.Id);
        }
        
        var company = _companyRepository.GetCompanyAsync(employee.CompanyId);
        var passport = _passportRepository.GetPassportAsync(employee.PassportId);
        var department = _departmentRepository.GetDepartmentAsync(employee.DepartmentId);

        Task.WaitAll(company, passport, department);

        return new GetEmployeeResponse
        {
            Id = employee.Id,
            Name = employee.Name,
            Surname = employee.Surname,
            Phone = employee.Phone,
            Company = company.Result,
            Passport = passport.Result,
            Department = department.Result
        };
    }
}