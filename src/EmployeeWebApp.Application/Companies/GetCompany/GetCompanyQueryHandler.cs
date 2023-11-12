using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Companies.GetCompany;

/// <summary>
/// Обработчик запроса <see cref="GetCompanyQuery"/>.
/// </summary>
public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, Company>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyQueryHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    /// <summary>
    /// Обрабатывает запрос <see cref="GetCompanyQuery"/>.
    /// </summary>
    /// <param name="request"><see cref="GetCompanyQuery"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Компания с указанным id.</returns>
    public async Task<Company> Handle(GetCompanyQuery request, CancellationToken cancellationToken = default)
    {
        var company = await _companyRepository.GetCompanyAsync(request.Id);

        if (company is null)
        {
            throw new CompanyNotFoundException(request.Id);
        }
        
        return company;
    }
}