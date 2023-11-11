using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace EmployeeWebApp.Application.Passports.AddPassport;

/// <summary>
/// Обработчик команды <see cref="AddPassportCommand"/>.
/// </summary>
public class AddPassportCommandHandler : IRequestHandler<AddPassportCommand, int>
{
    private readonly IPassportRepository _passportRepository;
    private readonly IValidator<AddPassportCommand> _validator;

    public AddPassportCommandHandler(IPassportRepository passportRepository, IValidator<AddPassportCommand> validator)
    {
        _passportRepository = passportRepository;
        _validator = validator;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="AddPassportCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="AddPassportCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Id паспорта.</returns>
    public async Task<int> Handle(AddPassportCommand request, CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidationException(validationResult.ToString());
        }
        
        var passport = new Passport { Type = request.Type, Number = request.Number };

        return await _passportRepository.AddPassportAsync(passport);
    }
}