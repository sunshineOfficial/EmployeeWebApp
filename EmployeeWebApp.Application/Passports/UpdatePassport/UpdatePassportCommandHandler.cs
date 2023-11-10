using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Passports.UpdatePassport;

/// <summary>
/// Обработчик команды <see cref="UpdatePassportCommand"/>.
/// </summary>
public class UpdatePassportCommandHandler : IRequestHandler<UpdatePassportCommand>
{
    private readonly IPassportRepository _passportRepository;

    public UpdatePassportCommandHandler(IPassportRepository passportRepository)
    {
        _passportRepository = passportRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="UpdatePassportCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="UpdatePassportCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(UpdatePassportCommand request, CancellationToken cancellationToken = default)
    {
        var passport = new Passport { Type = request.Type, Number = request.Number };

        await _passportRepository.UpdatePassportAsync(request.Id, passport);
    }
}