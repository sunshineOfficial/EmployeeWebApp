using EmployeeWebApp.Domain.Exceptions;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Departments.DeleteDepartment;

/// <summary>
/// Обработчик команды <see cref="DeleteDepartmentCommand"/>.
/// </summary>
public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
{
    private readonly IDepartmentRepository _departmentRepository;

    public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="DeleteDepartmentCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="DeleteDepartmentCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken = default)
    {
        if (!await _departmentRepository.DepartmentExistsAsync(request.Id))
        {
            throw new DepartmentNotFoundException(request.Id);
        }
        
        await _departmentRepository.DeleteDepartmentAsync(request.Id);
    }
}