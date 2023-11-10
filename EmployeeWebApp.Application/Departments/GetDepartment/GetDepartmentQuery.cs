using EmployeeWebApp.Domain.Entities;
using MediatR;

namespace EmployeeWebApp.Application.Departments.GetDepartment;

/// <summary>
/// Запрос на получение отдела.
/// </summary>
public class GetDepartmentQuery : IRequest<Department>
{
    /// <summary>
    /// Id отдела.
    /// </summary>
    public int Id { get; set; }
}