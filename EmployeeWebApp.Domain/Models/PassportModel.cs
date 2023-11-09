namespace EmployeeWebApp.Domain.Models;

/// <summary>
/// Модель сущности Паспорт.
/// </summary>
public class PassportModel
{
    /// <summary>
    /// Тип паспорта.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Номер паспорта.
    /// </summary>
    public string Number { get; set; }
}