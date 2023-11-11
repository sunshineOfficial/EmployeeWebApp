using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace EmployeeWebApp.Application.Companies.UpdateCompany;

/// <summary>
/// Обработчик команды <see cref="UpdateCompanyCommand"/>.
/// </summary>
public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IValidator<UpdateCompanyCommand> _validator;

    public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IValidator<UpdateCompanyCommand> validator)
    {
        _companyRepository = companyRepository;
        _validator = validator;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="UpdateCompanyCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="UpdateCompanyCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidationException(validationResult.ToString());
        }
        
        if (!await _companyRepository.CompanyExistsAsync(request.Id))
        {
            throw new CompanyNotFoundException(request.Id);
        }
        
        var company = new Company { Name = request.Name };

        await _companyRepository.UpdateCompanyAsync(request.Id, company);
    }
}