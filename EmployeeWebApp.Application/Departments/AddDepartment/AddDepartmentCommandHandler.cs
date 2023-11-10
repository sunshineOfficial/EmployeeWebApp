using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Departments.AddDepartment;

/// <summary>
/// Обработчик команды <see cref="AddDepartmentCommand"/>.
/// </summary>
public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, int>
{
    private readonly IDepartmentRepository _departmentRepository;

    public AddDepartmentCommandHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// Обрабатывает команду <see cref="AddDepartmentCommand"/>.
    /// </summary>
    /// <param name="request"><see cref="AddDepartmentCommand"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Id отдела.</returns>
    public async Task<int> Handle(AddDepartmentCommand request, CancellationToken cancellationToken = default)
    {
        var department = new Department { Name = request.Name, Phone = request.Phone };

        return await _departmentRepository.AddDepartmentAsync(department);
    }
}