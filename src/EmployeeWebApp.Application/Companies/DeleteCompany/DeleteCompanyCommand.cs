using MediatR;

namespace EmployeeWebApp.Application.Companies.DeleteCompany;

/// <summary>
/// Команда удаления компании.
/// </summary>
public class DeleteCompanyCommand : IRequest
{
    /// <summary>
    /// Id компании.
    /// </summary>
    public int Id { get; set; }
}