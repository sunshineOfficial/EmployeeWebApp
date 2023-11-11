using EmployeeWebApp.Application.Employees.GetEmployee;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Employees.GetEmployeesByCompanyId;

/// <summary>
/// Обработчик запроса <see cref="GetEmployeesByCompanyIdQuery"/>.
/// </summary>
public class GetEmployeesByCompanyIdQueryHandler : IRequestHandler<GetEmployeesByCompanyIdQuery, IEnumerable<GetEmployeeResponse>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IPassportRepository _passportRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public GetEmployeesByCompanyIdQueryHandler(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IPassportRepository passportRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _companyRepository = companyRepository;
        _passportRepository = passportRepository;
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// Обрабатывает запрос <see cref="GetEmployeesByCompanyIdQuery"/>.
    /// </summary>
    /// <param name="request"><see cref="GetEmployeesByCompanyIdQuery"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Перечисление, содержащее всех сотрудников для указанной компании.</returns>
    public async Task<IEnumerable<GetEmployeeResponse>> Handle(GetEmployeesByCompanyIdQuery request, CancellationToken cancellationToken = default)
    {
        var response = new List<GetEmployeeResponse>();
        var employees = await _employeeRepository.GetEmployeesByCompanyIdAsync(request.CompanyId);

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