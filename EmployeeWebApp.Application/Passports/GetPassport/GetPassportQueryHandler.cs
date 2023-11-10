using EmployeeWebApp.Domain.Entities;
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
        return await _passportRepository.GetPassportAsync(request.Id);
    }
}