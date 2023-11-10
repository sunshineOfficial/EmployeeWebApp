using MediatR;

namespace EmployeeWebApp.Application.Departments.AddDepartment;

/// <summary>
/// Команда добавления отдела.
/// </summary>
public class AddDepartmentCommand : IRequest<int>
{
    /// <summary>
    /// Название отдела.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Номер телефона отдела.
    /// </summary>
    public string Phone { get; set; }
}