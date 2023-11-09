namespace EmployeeWebApp.Infrastructure.Configuration;

/// <summary>
/// Конфигурация строк подключения к внешним ресурсамч.
/// </summary>
public class ConnectionStringsSettings
{
    /// <summary>
    /// Строка подключения к базе данных.
    /// </summary>
    public string DatabaseConnection { get; set; }
}