namespace EmployeeWebApp.Domain.Models;

/// <summary>
/// Модель сущности Отдел.
/// </summary>
public class DepartmentModel
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