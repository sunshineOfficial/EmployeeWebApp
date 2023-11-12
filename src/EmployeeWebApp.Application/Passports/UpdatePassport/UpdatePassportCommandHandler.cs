using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace EmployeeWebApp.Application.Passports.UpdatePassport;

/// <summary>
/// Обработчик команды <see cref="UpdatePassportCommand"/>.
/// </summary>
public class UpdatePassportCommandHandler : IRequestHandler<UpdatePassportCommand>
{
    private readonly IPassportRepository _passportRepository;
    private readonly IValidator<UpdatePassportCommand> _validator;

    public UpdatePassportCommandHandler(IPassportRepository passportRepository, IValidator<UpdatePassportCommand> validator)
    {
        _passportRepository = passportRepository;
        _validator = validator;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="UpdatePassportCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="UpdatePassportCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(UpdatePassportCommand request, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidationException(validationResult.ToString());
        }
        
        if (!await _passportRepository.PassportExistsAsync(request.Id))
        {
            throw new PassportNotFoundException(request.Id);
        }
        
        var passport = new Passport { Type = request.Type, Number = request.Number };

        await _passportRepository.UpdatePassportAsync(request.Id, passport);
    }
}