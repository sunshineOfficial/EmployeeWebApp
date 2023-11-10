using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Companies.DeleteCompany;

/// <summary>
/// Обработчик команды <see cref="DeleteCompanyCommand"/>.
/// </summary>
public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
{
    private readonly ICompanyRepository _companyRepository;

    public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="DeleteCompanyCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="DeleteCompanyCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken = default)
    {
        await _companyRepository.DeleteCompanyAsync(request.Id);
    }
}