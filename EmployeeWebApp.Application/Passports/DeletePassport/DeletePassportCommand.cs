using MediatR;

namespace EmployeeWebApp.Application.Passports.DeletePassport;

/// <summary>
/// Команда удаления паспорта.
/// </summary>
public class DeletePassportCommand : IRequest
{
    /// <summary>
    /// Id паспорта.
    /// </summary>
    public int Id { get; set; }
}