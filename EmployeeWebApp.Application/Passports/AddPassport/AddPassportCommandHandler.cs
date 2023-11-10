using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Passports.AddPassport;

/// <summary>
/// Обработчик команды <see cref="AddPassportCommand"/>.
/// </summary>
public class AddPassportCommandHandler : IRequestHandler<AddPassportCommand, int>
{
    private readonly IPassportRepository _passportRepository;

    public AddPassportCommandHandler(IPassportRepository passportRepository)
    {
        _passportRepository = passportRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="AddPassportCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="AddPassportCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Id паспорта.</returns>
    public async Task<int> Handle(AddPassportCommand request, CancellationToken cancellationToken = default)
    {
        var passport = new Passport { Type = request.Type, Number = request.Number };

        return await _passportRepository.AddPassportAsync(passport);
    }
}