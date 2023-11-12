using MediatR;

namespace EmployeeWebApp.Application.Passports.AddPassport;

/// <summary>
/// Команда добавления паспорта.
/// </summary>
public class AddPassportCommand : IRequest<int>
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