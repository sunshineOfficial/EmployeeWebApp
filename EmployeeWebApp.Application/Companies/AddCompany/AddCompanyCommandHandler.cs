using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Companies.AddCompany;

/// <summary>
/// Обработчик команды <see cref="AddCompanyCommand"/>.
/// </summary>
public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, int>
{
    private readonly ICompanyRepository _companyRepository;

    public AddCompanyCommandHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="AddCompanyCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="AddCompanyCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Id компании.</returns>
    public async Task<int> Handle(AddCompanyCommand request, CancellationToken cancellationToken = default)
    {
        var company = new Company
        {
            Name = request.Name
        };

        return await _companyRepository.AddCompanyAsync(company);
    }
}