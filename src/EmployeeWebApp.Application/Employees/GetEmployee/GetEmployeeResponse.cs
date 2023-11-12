using EmployeeWebApp.Domain.Entities;

namespace EmployeeWebApp.Application.Employees.GetEmployee;

/// <summary>
/// Ответ на запрос <see cref="GetEmployeeQuery"/>.
/// </summary>
public class GetEmployeeResponse
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
    /// Компания сотрудника.
    /// </summary>
    public Company Company { get; set; }

    /// <summary>
    /// Паспорт сотрудника.
    /// </summary>
    public Passport Passport { get; set; }

    /// <summary>
    /// Отдел сотрудника.
    /// </summary>
    public Department Department { get; set; }
}