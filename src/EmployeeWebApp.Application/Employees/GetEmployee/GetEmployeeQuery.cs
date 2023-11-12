using MediatR;

namespace EmployeeWebApp.Application.Employees.GetEmployee;

/// <summary>
/// Запрос на получение сотрудника.
/// </summary>
public class GetEmployeeQuery : IRequest<GetEmployeeResponse>
{
    /// <summary>
    /// Id сотрудника.
    /// </summary>
    public int Id { get; set; }
}