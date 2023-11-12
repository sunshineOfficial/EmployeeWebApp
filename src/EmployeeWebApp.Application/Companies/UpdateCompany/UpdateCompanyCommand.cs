using System.Text.Json.Serialization;
using MediatR;

namespace EmployeeWebApp.Application.Companies.UpdateCompany;

/// <summary>
/// Команда обновления компании.
/// </summary>
public class UpdateCompanyCommand : IRequest
{
    /// <summary>
    /// Id компании.
    /// </summary>
    [JsonIgnore]
    public int Id { get; set; }
    
    /// <summary>
    /// Название компании.
    /// </summary>
    public string Name { get; set; }
}