using EmployeeWebApp.Application.Employees.GetEmployee;
using MediatR;

namespace EmployeeWebApp.Application.Employees.GetEmployeesByCompanyId;

/// <summary>
/// Запрос на получение сотрудников по id компании.
/// </summary>
public class GetEmployeesByCompanyIdQuery : IRequest<IEnumerable<GetEmployeeResponse>>
{
    /// <summary>
    /// Id компании сотрудника.
    /// </summary>
    public int CompanyId { get; set; }
}