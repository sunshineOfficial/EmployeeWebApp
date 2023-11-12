using MediatR;

namespace EmployeeWebApp.Application.Employees.DeleteEmployee;

/// <summary>
/// Команда удаления сотрудника.
/// </summary>
public class DeleteEmployeeCommand : IRequest
{
    /// <summary>
    /// Id сотрудника.
    /// </summary>
    public int Id { get; set; }
}