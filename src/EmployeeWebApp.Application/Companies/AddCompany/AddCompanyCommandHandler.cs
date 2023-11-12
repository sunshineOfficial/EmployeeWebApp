using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace EmployeeWebApp.Application.Companies.AddCompany;

/// <summary>
/// Обработчик команды <see cref="AddCompanyCommand"/>.
/// </summary>
public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, int>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IValidator<AddCompanyCommand> _validator;

    public AddCompanyCommandHandler(ICompanyRepository companyRepository, IValidator<AddCompanyCommand> validator)
    {
        _companyRepository = companyRepository;
        _validator = validator;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="AddCompanyCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="AddCompanyCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Id компании.</returns>
    public async Task<int> Handle(AddCompanyCommand request, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidationException(validationResult.ToString());
        }
        
        var company = new Company
        {
            Name = request.Name
        };

        return await _companyRepository.AddCompanyAsync(company);
    }
}