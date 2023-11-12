using EmployeeWebApp.Domain.Entities;
using MediatR;

namespace EmployeeWebApp.Application.Companies.GetCompany;

/// <summary>
/// Запрос на получение компании.
/// </summary>
public class GetCompanyQuery : IRequest<Company>
{
    /// <summary>
    /// Id компании.
    /// </summary>
    public int Id { get; set; }
}