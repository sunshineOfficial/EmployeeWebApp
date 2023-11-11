using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Employees.DeleteEmployee;

/// <summary>
/// Обработчик команды <see cref="DeleteEmployeeCommand"/>.
/// </summary>
public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="DeleteEmployeeCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="DeleteEmployeeCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken = default)
    {
        await _employeeRepository.DeleteEmployeeAsync(request.Id);
    }
}