namespace EmployeeWebApp.Domain.Entities;

/// <summary>
/// Класс сущности Отдел.
/// </summary>
public class Department
{
    /// <summary>
    /// Id отдела.
    /// </summary>
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