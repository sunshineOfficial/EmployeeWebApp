using EmployeeWebApp.Domain.Entities;
using MediatR;

namespace EmployeeWebApp.Application.Passports.GetPassport;

/// <summary>
/// Запрос на получение паспорта.
/// </summary>
public class GetPassportQuery : IRequest<Passport>
{
    /// <summary>
    /// Id паспорта.
    /// </summary>
    public int Id { get; set; }
}