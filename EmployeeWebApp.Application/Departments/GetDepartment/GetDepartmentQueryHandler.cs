using EmployeeWebApp.Domain.Entities;
using EmployeeWebApp.Domain.Interfaces;
using MediatR;

namespace EmployeeWebApp.Application.Departments.GetDepartment;

/// <summary>
/// Обработчик запроса <see cref="GetDepartmentQuery"/>.
/// </summary>
public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, Department>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentQueryHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    /// <summary>
    /// Обрабатывает запрос <see cref="GetDepartmentQuery"/>.
    /// </summary>
    /// <param name="request"><see cref="GetDepartmentQuery"/>.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns>Отдел с указанным id.</returns>
    public async Task<Department> Handle(GetDepartmentQuery request, CancellationToken cancellationToken = default)
    {
        return await _departmentRepository.GetDepartmentAsync(request.Id);
    }
}