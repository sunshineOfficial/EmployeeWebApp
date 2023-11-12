using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Passports.GetPassport;

/// <summary>
/// Обработчик запроса <see cref="GetPassportQuery"/>.
/// </summary>
public class GetPassportQueryHandler : IRequestHandler<GetPassportQuery, Passport>
{
    private readonly IPassportRepository _passportRepository;

    public GetPassportQueryHandler(IPassportRepository passportRepository)
    {
        _passportRepository = passportRepository;
    }

    /// <summary>
    /// Обрабатывает запрос <see cref="GetPassportQuery"/>.
    /// </summary>
    /// <param name="request"><see cref="GetPassportQuery"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Паспорт с указанным id.</returns>
    public async Task<Passport> Handle(GetPassportQuery request, CancellationToken cancellationToken)
    {
        var passport = await _passportRepository.GetPassportAsync(request.Id);

        if (passport is null)
        {
            throw new PassportNotFoundException(request.Id);
        }
        
        return passport;
    }
}