namespace EmployeeWebApp.Domain.Entities;

/// <summary>
/// Класс сущности Сотрудник.
/// </summary>
public class Employee
{
    /// <summary>
    /// Id сотрудника.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя сотрудника.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Фамилия сотрудника.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Номер телефона сотрудника.
    /// </summary>
    public string Phone { get; set; }
    
    /// <summary>
    /// Id компании сотрудника.
    /// </summary>
    public int CompanyId { get; set; }

    /// <summary>
    /// Id паспорта сотрудника.
    /// </summary>
    public int PassportId { get; set; }

    /// <summary>
    /// Id отдела сотрудника.
    /// </summary>
    public int DepartmentId { get; set; }
}