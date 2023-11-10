using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Departments.UpdateDepartment;

/// <summary>
/// Обработчик команды <see cref="UpdateDepartmentCommand"/>.
/// </summary>
public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IDepartmentRepository _departmentRepository;

    public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="UpdateDepartmentCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="UpdateDepartmentCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken = default)
    {
        var department = new Department { Name = request.Name, Phone = request.Phone };

        await _departmentRepository.UpdateDepartmentAsync(request.Id, department);
    }
}