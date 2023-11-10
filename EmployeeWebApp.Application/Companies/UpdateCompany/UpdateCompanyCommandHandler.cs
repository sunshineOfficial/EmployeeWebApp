using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Companies.UpdateCompany;

/// <summary>
/// Обработчик команды <see cref="UpdateCompanyCommand"/>.
/// </summary>
public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly ICompanyRepository _companyRepository;

    public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="UpdateCompanyCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="UpdateCompanyCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken = default)
    {
        var company = new Company { Name = request.Name };

        await _companyRepository.UpdateCompanyAsync(request.Id, company);
    }
}