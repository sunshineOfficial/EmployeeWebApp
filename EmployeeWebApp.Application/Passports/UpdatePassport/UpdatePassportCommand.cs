using System.Text.Json.Serialization;
using MediatR;

namespace EmployeeWebApp.Application.Passports.UpdatePassport;

/// <summary>
/// Команда обновления паспорта.
/// </summary>
public class UpdatePassportCommand : IRequest
{
    /// <summary>
    /// Id паспорта.
    /// </summary>
    [JsonIgnore]
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