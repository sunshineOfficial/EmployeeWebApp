namespace EmployeeWebApp.Domain.Entities;

/// <summary>
/// Класс сущности Паспорт.
/// </summary>
public class Passport
{
    /// <summary>
    /// Id паспорта.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Тип паспорта.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Номер паспорта.
    /// </summary>
    public string Number { get; set; }
}