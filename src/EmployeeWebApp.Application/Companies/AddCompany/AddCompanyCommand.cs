using MediatR;

namespace EmployeeWebApp.Application.Companies.AddCompany;

/// <summary>
/// Команда добавления компании.
/// </summary>
public class AddCompanyCommand : IRequest<int>
{
    /// <summary>
    /// Название компании.
    /// </summary>
    public string Name { get; set; }
}