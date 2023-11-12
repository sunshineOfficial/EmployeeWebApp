namespace EmployeeWebApp.Domain.Entities;

/// <summary>
/// Класс сущности Компания.
/// </summary>
public class Company
{
    /// <summary>
    /// Id компании.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название компании.
    /// </summary>
    public string Name { get; set; }
}