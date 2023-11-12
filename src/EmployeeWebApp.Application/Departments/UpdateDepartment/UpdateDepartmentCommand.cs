using System.Text.Json.Serialization;
using MediatR;

namespace EmployeeWebApp.Application.Departments.UpdateDepartment;

/// <summary>
/// Команда обновления отдела.
/// </summary>
public class UpdateDepartmentCommand : IRequest
{
    /// <summary>
    /// Id отдела.
    /// </summary>
    [JsonIgnore]
    public int Id { get; set; }
    
    /// <summary>
    /// Название отдела.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Номер телефона отдела.
    /// </summary>
    public string Phone { get; set; }
}