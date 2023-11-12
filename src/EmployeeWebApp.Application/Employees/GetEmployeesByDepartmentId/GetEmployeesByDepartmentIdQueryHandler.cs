using EmployeeWebApp.Application.Employees.GetEmployee;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Employees.GetEmployeesByDepartmentId;

/// <summary>
/// Обработчик запроса <see cref="GetEmployeesByDepartmentIdQuery"/>.
/// </summary>
public class GetEmployeesByDepartmentIdQueryHandler : IRequestHandler<GetEmployeesByDepartmentIdQuery, IEnumerable<GetEmployeeResponse>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IPassportRepository _passportRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public GetEmployeesByDepartmentIdQueryHandler(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IPassportRepository passportRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _companyRepository = companyRepository;
        _passportRepository = passportRepository;
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// Обрабатывает запрос <see cref="GetEmployeesByDepartmentIdQuery"/>.
    /// </summary>
    /// <param name="request"><see cref="GetEmployeesByDepartmentIdQuery"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Перечисление, содержащее всех сотрудников для указанного отдела.</returns>
    public async Task<IEnumerable<GetEmployeeResponse>> Handle(GetEmployeesByDepartmentIdQuery request, CancellationToken cancellationToken = default)
    {
        var response = new List<GetEmployeeResponse>();
        var employees = await _employeeRepository.GetEmployeesByDepartmentIdAsync(request.DepartmentId);

        foreach (var employee in employees)
        {
            var company = _companyRepository.GetCompanyAsync(employee.CompanyId);
            var passport = _passportRepository.GetPassportAsync(employee.PassportId);
            var department = _departmentRepository.GetDepartmentAsync(employee.DepartmentId);

            Task.WaitAll(company, passport, department);
            
            response.Add(new GetEmployeeResponse
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Phone = employee.Phone,
                Company = company.Result,
                Passport = passport.Result,
                Department = department.Result
            });
        }

        return response;
    }
}