using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Passports.DeletePassport;

/// <summary>
/// Обработчик команды <see cref="DeletePassportCommand"/>.
/// </summary>
public class DeletePassportCommandHandler : IRequestHandler<DeletePassportCommand>
{
    private readonly IPassportRepository _passportRepository;

    public DeletePassportCommandHandler(IPassportRepository passportRepository)
    {
        _passportRepository = passportRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="DeletePassportCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="DeletePassportCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(DeletePassportCommand request, CancellationToken cancellationToken = default)
    {
        if (!await _passportRepository.PassportExistsAsync(request.Id))
        {
            throw new PassportNotFoundException(request.Id);
        }
        
        await _passportRepository.DeletePassportAsync(request.Id);
    }
}