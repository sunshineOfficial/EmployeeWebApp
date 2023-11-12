using EmployeeWebApp.Application.Employees.GetEmployee;
using MediatR;

namespace EmployeeWebApp.Application.Employees.GetEmployeesByDepartmentId;

/// <summary>
/// Запрос на получение сотрудников по id отдела.
/// </summary>
public class GetEmployeesByDepartmentIdQuery : IRequest<IEnumerable<GetEmployeeResponse>>
{
    /// <summary>
    /// Id отдела сотрудника.
    /// </summary>
    public int DepartmentId { get; set; }
}