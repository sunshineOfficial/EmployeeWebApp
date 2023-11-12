using MediatR;

namespace EmployeeWebApp.Application.Departments.DeleteDepartment;

/// <summary>
/// Команда удаления отдела.
/// </summary>
public class DeleteDepartmentCommand : IRequest
{
    /// <summary>
    /// Id отдела.
    /// </summary>
    public int Id { get; set; }
}